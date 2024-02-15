import 'package:flutter/material.dart';
import 'package:mobile_fitcc/Models/projekat.dart';
import 'package:mobile_fitcc/Models/requests/upsert_rezultat.dart';
import 'package:mobile_fitcc/Providers/rezultat_provider.dart';

class OcjenjivanjeProjektaScreen extends StatefulWidget {
  final Projekat? projekat;
  OcjenjivanjeProjektaScreen({this.projekat});

  @override
  _OcjenjivanjeProjektaScreenState createState() =>
      _OcjenjivanjeProjektaScreenState();
}

class _OcjenjivanjeProjektaScreenState
    extends State<OcjenjivanjeProjektaScreen> {
  final _formKey = GlobalKey<FormState>();
  final TextEditingController inovacijeController = TextEditingController();
  final TextEditingController napomenaController = TextEditingController();

  @override
  void dispose() {
    inovacijeController.dispose();
    napomenaController.dispose();
    super.dispose();
  }

  Future<void> _spasiOcjenu() async {
    try {
      RezultatUpsertRequest ocjena = RezultatUpsertRequest(
          int.parse(inovacijeController.text),
          napomenaController.text,
          widget.projekat!.projekatId);

      await RezultatProvider().insert(ocjena);
      Navigator.pop(context);
    } catch (e) {
      print('Error inserting Rezultat data: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Ocjenjivanje ${widget.projekat?.naziv}'),
      ),
      body: Form(
        key: _formKey,
        child: SingleChildScrollView(
          padding: EdgeInsets.all(16.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: <Widget>[
              Text('Naziv projekta: ${widget.projekat?.naziv ?? 'N/A'}'),
              SizedBox(height: 20),
              TextFormField(
                controller: inovacijeController,
                decoration: InputDecoration(labelText: 'Bodovi'),
                keyboardType: TextInputType.number,
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Ovo polje je obavezno';
                  }
                  if (int.tryParse(value) == null) {
                    return 'Unesite validan broj';
                  }
                  return null;
                },
              ),
              SizedBox(height: 10),
              TextFormField(
                controller: napomenaController,
                decoration: InputDecoration(labelText: 'Napomena'),
                maxLines: 3,
              ),
              SizedBox(height: 20),
              ElevatedButton(
                  child: Text('Ocijeni'),
                  onPressed: () {
                    if (_formKey.currentState!.validate()) {
                      _spasiOcjenu();
                    }
                  }),
            ],
          ),
        ),
      ),
    );
  }
}
