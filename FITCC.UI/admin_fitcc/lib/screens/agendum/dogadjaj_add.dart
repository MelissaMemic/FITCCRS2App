import 'package:admin_fitcc/models/agenda.dart';
import 'package:admin_fitcc/models/dogadjajagenda.dart';
import 'package:admin_fitcc/models/paged_result.dart';
import 'package:admin_fitcc/models/requests/insert_dogadjaj.dart';
import 'package:admin_fitcc/models/requests/update_dogadjaj.dart';
import 'package:admin_fitcc/providers/agenda_provider.dart';
import 'package:admin_fitcc/providers/dogadjaj_provider.dart';
import 'package:admin_fitcc/screens/agendum/agendum.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

class DogadjajAdd extends StatefulWidget {
  final DogadjajiPerAgenda? dogadjaj;
  DogadjajAdd({this.dogadjaj});

  @override
  _DogadjajAddState createState() => _DogadjajAddState();
}

class _DogadjajAddState extends State<DogadjajAdd> {
  List<Agenda> agendaList = [];
  int? selectedAgendaId;
  Agenda? preselectedAgenda;

  TextEditingController nazivController = TextEditingController();
  TextEditingController lokacijaController = TextEditingController();
  TextEditingController pocetakController = TextEditingController();
  TextEditingController trajanjeController = TextEditingController();
  TextEditingController napomenaController = TextEditingController();
  TextEditingController krajController = TextEditingController();
  TextEditingController dateTimeController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _fetchAgendaList();
    _initializeFormData();
  }

  void _initializeFormData() {
    if (widget.dogadjaj != null) {
      selectedAgendaId = widget.dogadjaj!.agendaId;
      nazivController.text = widget.dogadjaj!.naziv;
      lokacijaController.text = widget.dogadjaj!.lokacija;
      napomenaController.text =
          widget.dogadjaj!.napomena == null ? '' : widget.dogadjaj!.napomena!;
      krajController.text = widget.dogadjaj!.pocetak != null
          ? _formatDate(widget.dogadjaj!.kraj!)
          : '';
      trajanjeController.text = widget.dogadjaj!.trajanje?.toString() ?? '';
      pocetakController.text = widget.dogadjaj!.pocetak != null
          ? _formatDate(widget.dogadjaj!.pocetak!)
          : '';
    }
  }

  Future<void> _fetchAgendaList() async {
    try {
      PagedResult<Agenda> fetchedAgendaList = await AgendaProvider().get();
      setState(() {
        agendaList = fetchedAgendaList.result;
      });
    } catch (e) {
      print('Error fetching Agenda list: $e');
    }
  }

  Future<void> _insertDogadjaj() async {
    try {
      if (widget.dogadjaj != null) {
        DogadjajUpdateRequest updateObject = DogadjajUpdateRequest(
          nazivController.text,
          int.parse(trajanjeController.text),
          _parseDate(pocetakController.text),
          _parseDate(krajController.text),
          napomenaController.text,
          selectedAgendaId!,
          lokacijaController.text,
        );

        await DogadjajProvider()
            .update(widget.dogadjaj!.dogadjajId, updateObject);

        Navigator.push(
          context,
          MaterialPageRoute(builder: (context) => DogadjajList()),
        );
      } else {
        DogadjajInsertRequest insertObject = DogadjajInsertRequest(
          nazivController.text,
          int.parse(trajanjeController.text),
          DateTime.now(),
          DateTime.now(),
          'napomena',
          1,
          lokacijaController.text,
        );

        await DogadjajProvider().insert(insertObject);
        Navigator.push(
          context,
          MaterialPageRoute(builder: (context) => DogadjajList()),
        );
      }
    } catch (e) {
      print('Error inserting/updating Dogadjaj data: $e');
    }
  }

  Future<void> _selectDateTime(
      BuildContext context, TextEditingController control) async {
    final DateTime? pickedDate = await showDatePicker(
      context: context,
      initialDate: DateTime.now(),
      firstDate: DateTime(2000),
      lastDate: DateTime(2025),
    );
    if (pickedDate != null) {
      final TimeOfDay? pickedTime = await showTimePicker(
        context: context,
        initialTime: TimeOfDay.now(),
      );
      if (pickedTime != null) {
        final DateTime finalDateTime = DateTime(
          pickedDate.year,
          pickedDate.month,
          pickedDate.day,
          pickedTime.hour,
          pickedTime.minute,
        );
        setState(() {
          control.text =
              DateFormat('yyyy-MM-dd HH:mm:ss').format(finalDateTime);
        });
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    List<DropdownMenuItem<int>> agende = agendaList.map((agenda) {
      return DropdownMenuItem<int>(
        value: agenda.agendaId,
        child: Text(agenda.dan.toString()),
      );
    }).toList();

    return Scaffold(
      appBar: AppBar(
        title: Text(widget.dogadjaj != null ? 'Edit Dogadjaj' : 'Add Dogadjaj'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            if (widget.dogadjaj != null)
              Text(
                'Dogadjaj ID: ${widget.dogadjaj!.dogadjajId}',
                style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
              ),
            TextField(
              controller: nazivController,
              decoration: InputDecoration(labelText: 'Naziv'),
            ),
            TextField(
              controller: napomenaController,
              decoration: InputDecoration(labelText: 'Napomena'),
            ),
            TextField(
              controller: lokacijaController,
              decoration: InputDecoration(labelText: 'Lokacija'),
            ),
            TextField(
              controller: trajanjeController,
              decoration: InputDecoration(labelText: 'Trajanje u minutama'),
            ),
            DropdownButtonFormField<int>(
              value: selectedAgendaId,
              onChanged: (int? newValue) {
                setState(() {
                  selectedAgendaId = newValue;
                });
              },
              items: agende,
              decoration: InputDecoration(labelText: 'Dan'),
            ),
            SizedBox(height: 16),
            TextFormField(
              controller: pocetakController,
              decoration: InputDecoration(
                labelText: 'Pocetak',
                suffixIcon: IconButton(
                  icon: Icon(Icons.calendar_today),
                  onPressed: () => _selectDateTime(context, pocetakController),
                ),
              ),
              readOnly: true, // To prevent manual editing
            ),
            SizedBox(height: 16),
            TextFormField(
              controller: krajController,
              decoration: InputDecoration(
                labelText: 'Kraj',
                suffixIcon: IconButton(
                  icon: Icon(Icons.calendar_today),
                  onPressed: () => _selectDateTime(context, krajController),
                ),
              ),
              readOnly: true, // To prevent manual editing
            ),
            SizedBox(height: 16),
            ElevatedButton(
              onPressed: () {
                _insertDogadjaj();
              },
              child: Text(widget.dogadjaj == null
                  ? 'Dodaj Dogadjaj'
                  : 'Spasi promjene'),
            ),
          ],
        ),
      ),
    );
  }

  DateTime _parseDate(String dateString) {
    try {
      return DateFormat('yyyy-MM-dd HH:mm:ss').parse(dateString);
    } catch (e) {
      print('Error parsing date: $e');
      throw Exception('Invalid date format');
    }
  }

  String _formatDate(DateTime date) {
    return DateFormat('yyyy-MM-dd HH:mm:ss').format(date);
  }
}
