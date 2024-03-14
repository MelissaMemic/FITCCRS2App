import 'package:admin_fitcc/models/kategorija.dart';
import 'package:admin_fitcc/models/paged_result.dart';
import 'package:admin_fitcc/models/projekat.dart';
import 'package:admin_fitcc/models/tim.dart';
import 'package:admin_fitcc/providers/kategorija_provider.dart';
import 'package:admin_fitcc/providers/projekat_provider.dart';
import 'package:admin_fitcc/providers/tim_provider.dart';
import 'package:admin_fitcc/screens/timovi/tim_add.dart';
import 'package:admin_fitcc/screens/welcome/home_page.dart';
import 'package:flutter/material.dart';

class TimList extends StatefulWidget {
  @override
  _TimListState createState() => _TimListState();
}

class _TimListState extends State<TimList> {
  List<Tim> teamsList = [];
  List<Projekat> projectsList = [];
  List<Kategorija> kategorijeOptions = [];
  String selectedKategorija = 'All';
  Kategorija? latestKategorija;

  @override
  void initState() {
    super.initState();
    _fetchTeamsData();
    _fetchProjectsData();
    _fetchKategorijeOptions();
  }
Future<void> _fetchKategorijeOptions() async {
    try {
      PagedResult<Kategorija> fetchedKategorijeOptions =
          await KategorijaProvider().get();
      setState(() {
        kategorijeOptions=fetchedKategorijeOptions.result;
      });
    } catch (e) {
      print('Error fetching Kategorije options: $e');
    }
  }
  Future<void> _fetchTeamsData() async {
    try {
      PagedResult<Tim> fetchedTeamsList = await TimProvider().get();
      setState(() {
        teamsList = fetchedTeamsList.result;
      });
    } catch (e) {
      print('Error fetching Teams data: $e');
    }
  }

  Future<void> _fetchProjectsData() async {
    try {
      PagedResult<Projekat> fetchedProjectsList =
          await ProjekatProvider().get();
      setState(() {
        projectsList = fetchedProjectsList.result;
      });
    } catch (e) {
      print('Error fetching Projects data: $e');
    }
  }
List<Map<String, dynamic>> _getJoinedData() {
    return teamsList.map((tim) {
Projekat project;
try {
  project = projectsList.firstWhere(
    (proj) => proj.timId == tim.timId,
  );
} catch (e) {
  throw StateError('No matching element found in projectsList');
}
      return {
        'tim': tim,
        'timId': tim.timId,
        'projectnaziv': project != null ? project.naziv : 'N/A',
        'projectKategorija': project != null ? project.kategorijaId.toString() : 'N/A',
      };
    }).toList();
  }

  List<Map<String, dynamic>> _getFilteredData() {
    var allData = _getJoinedData();
    if (selectedKategorija == 'All') {
      return allData;
    } else {
      return allData.where((data) => data['projectKategorija'] == selectedKategorija).toList();
    }
  }

  @override
  Widget build(BuildContext context) {
       var filteredData = _getFilteredData();

    return Scaffold(
      appBar: AppBar(
        title: Text('Teams'),
      ),
      body: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
         Padding(
            padding: const EdgeInsets.all(8.0),
            child: DropdownButton<String>(
              value: selectedKategorija,
              onChanged: (value) {
                setState(() {
                  selectedKategorija = value!;
                });
              },
              items: [
                DropdownMenuItem<String>(
                  value: 'All',
                  child: Text('Odaberi kategoriju'),
                ),
                ...kategorijeOptions.map((kategorija) {
                  return DropdownMenuItem<String>(
                    value: kategorija.kategorijaId.toString(),
                    child: Text(kategorija.naziv.toString()),
                  );
                }).toList(),
              ],
            ),
          ),
         Expanded(
            child: DataTable(
              columns: const [
                DataColumn(label: Text('Tim Naziv')),
                DataColumn(label: Text('Broj clanova')),
                DataColumn(label: Text('Kategorija Projekta')),
                DataColumn(label: Text('')),
                DataColumn(label: Text('')),
              ],
              rows: filteredData.map((data) {
                return DataRow(cells: [
                  DataCell(Text(data['tim'].naziv)),
                  DataCell(Text(data['tim'].brojClanova.toString())),
                  DataCell(Text(data['projectnaziv'])),
                  
                  DataCell(
                    ElevatedButton(
                      onPressed: () {
                        _deleteTim(data['timId']); 
                      },
                      style: ElevatedButton.styleFrom(primary: Colors.red),
                      child: Text('Izbrisi'),
                    ),
                  ),
                  DataCell(
                    ElevatedButton(
                      onPressed: () {
                        _editTim(data['tim']); 
                      },
                      style: ElevatedButton.styleFrom(primary: Colors.blue),
                      child: Text('Uredi'),
                    ),
                  ),
                ]);
              }).toList(),
            ),
          ),
        ],
      ),
    );
  }
  void _deleteTim(int timId) async {
  try {
      await TimProvider().delete(timId);
          showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('Dogodila se greska'),
          content: Text('Provjerite da li ima projekat povezan na ovaj tim, ukoliko je to slucaj Tim nije moguce obrisati.'),
          actions: <Widget>[
            TextButton(
              onPressed: () {
                Navigator.of(context).pop(); // Close the dialog
              },
              child: Text('OK'),
            ),
          ],
        );
      },
    );

  } catch (e) {
    print('Error deleting tim: $e');
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('Dogodila se greska'),
          content: Text('Tim nije moguce obrisati, povezan je na vec postojeci projekat.'),
          actions: <Widget>[
            TextButton(
              onPressed: () {
                Navigator.of(context).pop(); // Close the dialog
              },
              child: Text('OK'),
            ),
          ],
        );
      },
    );
  }
}

  

void _editTim(Tim tim) {
    Navigator.push(
      context,
      MaterialPageRoute(builder: (context) => TimAdd(tim: tim)),
    );
  }
}
