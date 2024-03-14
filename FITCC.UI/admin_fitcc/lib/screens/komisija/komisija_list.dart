import 'package:admin_fitcc/models/kategorija.dart';
import 'package:admin_fitcc/models/komisija.dart';
import 'package:admin_fitcc/models/paged_result.dart';
import 'package:admin_fitcc/providers/kategorija_provider.dart';
import 'package:admin_fitcc/providers/komisija_provider.dart';
import 'package:admin_fitcc/screens/komisija/komsija_add.dart';
import 'package:flutter/material.dart';

class KomisijaList extends StatefulWidget {
  @override
  _KomisijaListState createState() => _KomisijaListState();
}

class _KomisijaListState extends State<KomisijaList> {
  List<Komisija> komisijaList = [];
  List<Kategorija> kategorijeOptions = [];
  String selectedKategorija = 'All';

  @override
  void initState() {
    super.initState();
    _fetchKomisijaData();
    _fetchKategorijeOptions();
  }

  Future<void> _fetchKomisijaData() async {
    try {
      PagedResult<Komisija> fetchedKomisijaList =
          await KomisijaProvider().get();
      setState(() {
        komisijaList = fetchedKomisijaList.result;
      });
    } catch (e) {
      print('Error fetching Komisija data: $e');
    }
  }

  Future<void> _fetchKategorijeOptions() async {
    try {
      PagedResult<Kategorija> fetchedKategorijeOptions =
          await KategorijaProvider().get();
      setState(() {
        kategorijeOptions = fetchedKategorijeOptions.result;
      });
    } catch (e) {
      print('Error fetching Kategorije options: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    List<Komisija> filteredKomisijaList = komisijaList
        .where((komisija) =>
            selectedKategorija == 'All' ||
            komisija.kategorijaId.toString() == selectedKategorija)
        .toList();
    return Scaffold(
      appBar: AppBar(
        title: Text('Komisija'),
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
                    child: Text(kategorija.naziv),
                  );
                }).toList(),
              ],
            ),
          ),
          Expanded(
            child: DataTable(
              columns: [
                DataColumn(label: Text('Ime i prezime')),
                DataColumn(label: Text('Email')),
                DataColumn(label: Text('Rola')),
                DataColumn(label: Text(' ')),
                DataColumn(label: Text(' ')),
              ],
              rows: filteredKomisijaList.map((rezultat) {
                return DataRow(cells: [
                  DataCell(Text('${rezultat.ime} ${rezultat.prezime}'),),
                  DataCell(Text(rezultat.email.toString())),
                  DataCell(Text(rezultat.role.name)),
                  DataCell(
                    ElevatedButton(
                      onPressed: () {
                        _deleteKomisija(rezultat.komisijaId);
                      },
                      style: ElevatedButton.styleFrom(primary: Colors.red),
                      child: Text('Izbrisi'),
                    ),
                  ),
                   DataCell(
                    ElevatedButton(
                      onPressed: () {
                        _editKomisija(rezultat);
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
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => KomisijaAdd()),
          );
        },
        tooltip: 'Dodaj',
        child: Icon(Icons.add),
      ),
    );
  }

  void _deleteKomisija(int komisijaID) async {
    try {
      await KomisijaProvider().delete(komisijaID);
      _fetchKomisijaData();
    } catch (e) {
      print('Error deleting komisija: $e');
    }
  }

  void _editKomisija(Komisija komisija) {
    Navigator.push(
      context,
      MaterialPageRoute(builder: (context) => KomisijaAdd(komisija: komisija)),
    );
  }
}
