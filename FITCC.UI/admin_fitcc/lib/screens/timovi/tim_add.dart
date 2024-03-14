import 'package:admin_fitcc/models/requests/insert_tim.dart';
import 'package:admin_fitcc/models/tim.dart';
import 'package:admin_fitcc/providers/takmicenje_provider.dart';
import 'package:admin_fitcc/providers/tim_provider.dart';
import 'package:admin_fitcc/screens/welcome/home_page.dart';
import 'package:flutter/material.dart';

class TimAdd extends StatefulWidget {
  final Tim? tim;
  TimAdd({this.tim});

  @override
  _TimAddState createState() => _TimAddState();
}

class _TimAddState extends State<TimAdd> {
  TextEditingController nazivController = TextEditingController();
  TextEditingController clanoviController = TextEditingController();
int? lastTakmicenje;
  @override
  void initState() {
    super.initState();
    _getTakmicenje();
    _loadData();
  }

  Future<void> _loadData() async {
    
    if (widget.tim?.timId != null) {
      nazivController.text = widget.tim!.naziv!;
      clanoviController.text = widget.tim!.brojClanova.toString();
    }
  }Future<void> _getTakmicenje() async {
    lastTakmicenje= await TakmicenjeProvider().getLastTakmicenje();
  }

  Future<void> _insertTim() async {
    try {
      TimInsertRequest tim = TimInsertRequest(
            lastTakmicenje,
            nazivController.text,
            int.parse(clanoviController.text),
           );
        await TimProvider().update(widget.tim!.timId,tim );
    Navigator.push(
      context,
      MaterialPageRoute(
        builder: (context) =>MyHomePage(),
      ),
    );
    } catch (e) {
      print('Error inserting Tim data: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Add Tim'),
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
              controller: clanoviController,
              decoration: InputDecoration(labelText: 'Broj clanova'),
            ),
            SizedBox(height: 16),
            ElevatedButton(
              onPressed: () {
                _insertTim();
              },
              child: Text(
                  widget.tim == null ? 'Dodaj Kriterij' : 'Spasi izmjene'),
            ),
          ],
        ),
      ),
    );
  }
}
