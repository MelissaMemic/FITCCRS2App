import 'package:admin_fitcc/models/auth_user.dart';
import 'package:admin_fitcc/models/enums/role.dart';
import 'package:admin_fitcc/screens/agendum/agendum.dart';
import 'package:admin_fitcc/screens/komisija/komisija_list.dart';
import 'package:admin_fitcc/screens/kriteriji/kriteriji_list.dart';
import 'package:admin_fitcc/screens/projekti/projekat_list.dart';
import 'package:admin_fitcc/screens/rezultati/rezultati_list.dart';
import 'package:admin_fitcc/screens/timovi/timovi_list.dart';
import 'package:flutter/material.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Desktop Menu',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: MyHomePage(),
    );
  }
}

class MyHomePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('FITCC Menu'),
      ),
      body: Center(
        child: Text(
          'Welcome to the FITCC!',
          style: TextStyle(fontSize: 24),
        ),
      ),
      drawer: Drawer(
        child: ListView(
          padding: EdgeInsets.zero,
          children: <Widget>[
            DrawerHeader(
              decoration: BoxDecoration(
                color: Colors.blue,
              ),
              child: Text(
                'Menu',
                style: TextStyle(
                  color: Colors.white,
                  fontSize: 24,
                ),
              ),
            ),
            ListTile(
              title: Text('Home'),
              onTap: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => MyHomePage()),
                );
              },
            ),
           if (AuthUser.roles.contains("Admin"))
            ListTile(
              title: Text('Komisija'),
              onTap: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => KomisijaList()),
                );
              },
            ),
           if (AuthUser.roles.contains("Admin"))
            ListTile(
              title: Text('Projekti'),
              onTap: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => ProjekatList()),
                );
              },
            ),
           if (AuthUser.roles.contains("Admin"))
            ListTile(
              title: Text('Agendum'),
              onTap: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => DogadjajList()),
                );
              },
            ),
            if (AuthUser.roles.contains("Admin"))
            ListTile(
              title: Text('Timovi'),
              onTap: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => TimList()),
                );
              },
            ),
            if (AuthUser.roles.contains("Admin"))
            ListTile(
              title: Text('Kriteriji'),
              onTap: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => KriterijiList()),
                );
              },
            ),
            if (AuthUser.roles.contains("Admin"))
            ListTile(
              title: Text('Rezultati'),
              onTap: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => RezultatiList()),
                );
              },
            ),
          ],
        ),
      ),
    );
  }
}
