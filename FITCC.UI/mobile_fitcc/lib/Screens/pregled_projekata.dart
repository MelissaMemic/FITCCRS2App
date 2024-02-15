import 'package:flutter/material.dart';
import 'package:mobile_fitcc/Models/kategorija.dart';
import 'package:mobile_fitcc/Models/paged_result.dart';
import 'package:mobile_fitcc/Models/projekat.dart';
import 'package:mobile_fitcc/Models/projekt_tim.dart';
import 'package:mobile_fitcc/Models/tim.dart';
import 'package:mobile_fitcc/Providers/kategorija_provider.dart';
import 'package:mobile_fitcc/Providers/projekat_provider.dart';
import 'package:mobile_fitcc/Screens/ocjenjivanje_projekata.dart';

class PregledProjekataScreen extends StatefulWidget {
  @override
  _PregledProjekataScreenState createState() => _PregledProjekataScreenState();
}

class _PregledProjekataScreenState extends State<PregledProjekataScreen> {
  List<Projekat> projekti = [];
  List<ProjekatTimInfo> combinedLista = [];
    List<Kategorija> kategorijeOptions = [];
      String selectedKategorija = 'All';


  List<Tim> timovi = [];
  @override
  void initState() {
    super.initState();
    _fetchProjekatData();
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

  Future<void> _fetchProjekatData() async {
    try {
      PagedResult<Projekat> fetchedprojektiList =
          await ProjekatProvider().get();
      // PagedResult<Tim> fetchedtimoviList = await TimProvider().get();

      // List<ProjekatTimInfo> newCombinedList = [];
      // var timMap = {for (var tim in fetchedtimoviList.result) tim.timId: tim};

      // for (var projekat in fetchedprojektiList.result) {
      //   // Tim correspondingTim = timMap[projekat.timId] ?? Tim(timId:1,naziv: 'test',brojClanova:1,userId:1,username: 'name',takmicenjeId: 1); // Provide a default Tim object if not found

      //   //   newCombinedList.add(ProjekatTimInfo(projekat: projekat, tim: correspondingTim));
      // }
      setState(() {
        projekti = fetchedprojektiList.result;
        // timovi = fetchedtimoviList.result;
        // combinedLista = newCombinedList;
      });
    } catch (e) {
      print('Error fetching Projekat data: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
     List<Projekat> filteredRezultatiList = projekti
        .where((rezultat) =>
            selectedKategorija == 'All' ||
            rezultat.kategorijaId.toString() == selectedKategorija)
        .toList();

    return Scaffold(
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
              columns: [
                DataColumn(label: Text('Naziv')),
                DataColumn(label: Text('Opis')),
                DataColumn(label: Text(' ')),
              ],
              rows: filteredRezultatiList.map((projekat) {
                return DataRow(cells: [
                  DataCell(Text(projekat.naziv)),
                  DataCell(Text(projekat.tim.naziv!)),
                  DataCell(
                    ElevatedButton(
                      onPressed: () {
                        Navigator.push(
                          context,
                          MaterialPageRoute(
                              builder: (context) => OcjenjivanjeProjektaScreen(
                                  projekat: projekat)),
                        );
                      },
                      child: Text('Ocjeni'),
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
}
