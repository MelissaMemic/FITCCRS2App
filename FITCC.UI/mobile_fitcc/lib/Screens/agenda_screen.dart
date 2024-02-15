import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:mobile_fitcc/Models/dogadjajagenda.dart';
import 'package:mobile_fitcc/Providers/dogadjaj_provider.dart';
import 'package:mobile_fitcc/Providers/dogadjajiperagenda_provider.dart';

class AgendaScreen extends StatefulWidget {
  const AgendaScreen({super.key});
  @override
  _AgendaState createState() => _AgendaState();
}

class _AgendaState extends State<AgendaScreen> {
  List<DogadjajiPerAgenda> _lista = [];

  var dogadjajService = DogadjajProvider();
  List _agenda = [];

  @override
  void initState() {
    super.initState();
    _fetchData();
  }

  Future<void> _fetchData() async {
    try {
      List<DogadjajiPerAgenda> fetchedlist =
          await DogadjajPerAgendaProvider().fetchDogadjajperAgendaList();
      setState(() {
        _lista = fetchedlist;
      });
    } catch (e) {
      print('Error fetching List data: $e');
    }
  }

Map<int, List<DogadjajiPerAgenda>> groupEventsByDay(List<DogadjajiPerAgenda> events) {
    Map<int, List<DogadjajiPerAgenda>> grouped = {};
    for (var event in events) {
      (grouped[event.dan!] ??= []).add(event);
    }
    return grouped;
  }
  @override
  Widget build(BuildContext context) {
    Map<int, List<DogadjajiPerAgenda>> groupedEvents = groupEventsByDay(_lista);

    return Scaffold(
      appBar: AppBar(
        title: Text('Agenda'),
      ),
      body: groupedEvents.isEmpty
          ? Center(child: Text("Nema podataka", style: TextStyle(fontSize: 20)))
          : ListView(
              children: groupedEvents.entries.map((entry) {
                return ExpansionTile(
                  title: Text('Dan ${entry.key}'),
                  children: entry.value.map((event) {
                    return Row(
                      children: [
                        Expanded(
                          child: Text(event.naziv, textAlign: TextAlign.center),
                        ),
                        Expanded(
                          child: Text(
                            event.pocetak != null ? 
                              DateFormat('HH:mm').format(event.pocetak!) : 'N/A', 
                            textAlign: TextAlign.center
                          ),
                        ),
                        Expanded(
                          child: Text(event.lokacija, textAlign: TextAlign.center),
                        ),
                      ],
                    );
                  }).toList(),
                );
              }).toList(),
            ),
    );
  }
}
