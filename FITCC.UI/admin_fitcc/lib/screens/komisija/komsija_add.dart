import 'package:admin_fitcc/models/paged_result.dart';
import 'package:admin_fitcc/models/requests/insert_komisija.dart';
import 'package:flutter/material.dart';
import 'package:admin_fitcc/models/komisija.dart';
import 'package:admin_fitcc/models/enums/ulogeKomisije.dart';
import 'package:admin_fitcc/models/kategorija.dart';
import 'package:admin_fitcc/providers/komisija_provider.dart';
import 'package:admin_fitcc/providers/kategorija_provider.dart';

class KomisijaAdd extends StatefulWidget {
  final Komisija? komisija;
  KomisijaAdd({this.komisija});

  @override
  _KomisijaAddState createState() => _KomisijaAddState();
}

class _KomisijaAddState extends State<KomisijaAdd> {
  TextEditingController imeController = TextEditingController();
  TextEditingController prezimeController = TextEditingController();
  TextEditingController emailController = TextEditingController();
  UlogeKomisije? selectedUlogeKomisije;
  int? selectedKategorijaId;

  List<UlogeKomisije> ulogeKomisijeList = [];
  List<Kategorija> kategorijeList = [];

  @override
  void initState() {
    super.initState();
    _fetchKategorijeList();
    _initializeFormData();
  }

  void _initializeFormData() {
    if (widget.komisija != null) {
      imeController.text = widget.komisija!.ime ?? '';
      prezimeController.text = widget.komisija!.prezime ?? '';
      emailController.text = widget.komisija!.email ?? '';
      selectedUlogeKomisije = widget.komisija!.role;
      selectedKategorijaId = widget.komisija!.kategorijaId;
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

  Future<void> _saveKomisija() async {
    try {
      if (widget.komisija == null) {
        KomisijaInsertRequest komisija = KomisijaInsertRequest(
          imeController.text,
          prezimeController.text,
          emailController.text,
          UlogeKomisije.values.firstWhere(
              (e) => e.toString() == selectedUlogeKomisije.toString()),
          selectedKategorijaId!,
        );

        await KomisijaProvider().insert(komisija);
        Navigator.pop(context);
      } else {
        Komisija komisija = Komisija(
          widget.komisija!.komisijaId,
          imeController.text,
          prezimeController.text,
          emailController.text,
          UlogeKomisije.values.firstWhere(
              (e) => e.toString() == selectedUlogeKomisije.toString()),
          selectedKategorijaId!,
        );
        komisija.komisijaId = widget.komisija!.komisijaId;
        await KomisijaProvider().update(komisija.komisijaId, komisija);
        Navigator.pop(context);
      }
    } catch (e) {
      print('Error saving Komisija data: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    List<DropdownMenuItem<UlogeKomisije>> ulogeKomisijeDropdownItems =
        UlogeKomisije.values.map((role) {
      return DropdownMenuItem<UlogeKomisije>(
        value: role,
        child: Text(role.toString().split('.').last),
      );
    }).toList();

    List<DropdownMenuItem<int>> kategorijaDropdownItems =
        kategorijeList.map((kategorija) {
      return DropdownMenuItem<int>(
        value: kategorija.kategorijaId,
        child: Text(kategorija.naziv),
      );
    }).toList();

    return Scaffold(
      appBar: AppBar(
        title: Text('Add Komisija'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            TextField(
              controller: imeController,
              decoration: InputDecoration(labelText: 'Ime'),
            ),
            TextField(
              controller: prezimeController,
              decoration: InputDecoration(labelText: 'Prezime'),
            ),
            TextField(
              controller: emailController,
              decoration: InputDecoration(labelText: 'Email'),
            ),
            DropdownButtonFormField<UlogeKomisije>(
              value: selectedUlogeKomisije,
              onChanged: (UlogeKomisije? newValue) {
                setState(() {
                  selectedUlogeKomisije = newValue;
                });
              },
              items: ulogeKomisijeDropdownItems,
              decoration: InputDecoration(labelText: 'Uloga Komisije'),
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
              onPressed: _saveKomisija,
              child: Text('Dodaj Komisiju'),
            ),
          ],
        ),
      ),
    );
  }
}
