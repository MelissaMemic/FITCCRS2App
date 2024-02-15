import 'package:admin_fitcc/models/kriterij.dart';
import 'package:admin_fitcc/models/paged_result.dart';
import 'package:admin_fitcc/models/requests/upsert_kriterij.dart';
import 'package:admin_fitcc/providers/kriterij_provider.dart';
import 'package:admin_fitcc/screens/welcome/home_page.dart';
import 'package:flutter/material.dart';
import 'package:admin_fitcc/models/kategorija.dart';
import 'package:admin_fitcc/providers/kategorija_provider.dart';

class KriterijAdd extends StatefulWidget {
  final Kriterij? kriterij;
  KriterijAdd({this.kriterij});

  @override
  _KriterijAddState createState() => _KriterijAddState();
}

class _KriterijAddState extends State<KriterijAdd> {
  TextEditingController nazivController = TextEditingController();
  TextEditingController vrijednostController = TextEditingController();
  int? selectedKategorijaId;
  List<Kategorija> kategorijeList = [];

  @override
  void initState() {
    super.initState();
    _fetchKategorijeList();
    _loadData();
  }

  Future<void> _loadData() async {
    if (widget.kriterij != null) {
      selectedKategorijaId = widget.kriterij!.kategorijaId;
      nazivController.text = widget.kriterij!.naziv;
      vrijednostController.text = widget.kriterij!.vrijednost;
    }
  }

  Future<void> _fetchKategorijeList() async {
    try {
      PagedResult<Kategorija> fetchedKategorijeList =
          await KategorijaProvider().get();
      setState(() {
        kategorijeList = fetchedKategorijeList.result;
      });
    } catch (e) {
      print('Error fetching Kategorije data: $e');
    }
  }

  Future<void> _insertKriterij() async {
    try {
      KriterijUpsertRequest kriterij = KriterijUpsertRequest(
            nazivController.text,
            vrijednostController.text,
            selectedKategorijaId!);
      if (widget.kriterij != null) {
        
        await KriterijProvider().update(widget.kriterij!.kriterijId,kriterij );
    Navigator.push(
      context,
      MaterialPageRoute(
        builder: (context) =>MyHomePage(),
      ),
    );

      } else {
        await KriterijProvider().insert(kriterij );
 Navigator.push(
      context,
      MaterialPageRoute(
        builder: (context) =>MyHomePage(),
      ),
    );
      }
    } catch (e) {
      print('Error inserting Kriterij data: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    List<DropdownMenuItem<int>> kategorijaDropdownItems =
        kategorijeList.map((kategorija) {
      return DropdownMenuItem<int>(
        value: kategorija.kategorijaId,
        child: Text(kategorija.naziv),
      );
    }).toList();

    return Scaffold(
      appBar: AppBar(
        title: Text('Add Kriterij'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            TextField(
              controller: nazivController,
              decoration: InputDecoration(labelText: 'Naziv'),
            ),
            TextField(
              controller: vrijednostController,
              decoration: InputDecoration(labelText: 'Vrijednost'),
            ),
            DropdownButtonFormField<int>(
              value: selectedKategorijaId,
              onChanged: (int? newValue) {
                setState(() {
                  selectedKategorijaId = newValue;
                });
              },
              items: kategorijaDropdownItems,
              decoration: InputDecoration(labelText: 'Kategorija'),
            ),
            SizedBox(height: 16),
            ElevatedButton(
              onPressed: () {
                _insertKriterij();
              },
              child: Text(
                  widget.kriterij == null ? 'Dodaj Kriterij' : 'Spasi izmjene'),
            ),
          ],
        ),
      ),
    );
  }
}
