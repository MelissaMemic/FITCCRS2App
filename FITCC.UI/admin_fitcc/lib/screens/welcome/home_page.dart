import 'package:flutter/material.dart';
import 'package:admin_fitcc/models/auth_user.dart';
import 'package:admin_fitcc/screens/agendum/agendum.dart';
import 'package:admin_fitcc/screens/komisija/komisija_list.dart';
import 'package:admin_fitcc/screens/projekti/projekat_list.dart';
import 'package:admin_fitcc/screens/login_page.dart';
import 'package:admin_fitcc/screens/rezultati/rezultati_list.dart';
import 'package:admin_fitcc/screens/timovi/timovi_list.dart';
import 'package:admin_fitcc/screens/kriteriji/kriteriji_list.dart';

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
    final GlobalKey<DrawerControllerState> _drawerKey = GlobalKey();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(
          'FITCC Menu',
          style: TextStyle(color: Colors.white),
        ),
      ),
      body: Stack(
        children: [
          Container(
            decoration: BoxDecoration(
              image: DecorationImage(
                image: AssetImage('assets/images/space.jpg'),
                fit: BoxFit.cover,
              ),
            ),
          ),
          Center(
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Text(
                  'Dobrodosli na admin panel FITCC-a',
                  style: TextStyle(fontSize: 24, color: Colors.white),
                ),
                SizedBox(height: 20),
                ElevatedButton(
                  onPressed: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(builder: (context) => DogadjajList()),
                    );
                  },
                  style: ElevatedButton.styleFrom(
                    primary: Colors.transparent,
                    onPrimary: Colors.white,
                    side: BorderSide(color: Colors.white, width: 2),
                  ),
                  child: Padding(
                    padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
                    child: Text('Agenda'),
                  ),
                ),
                SizedBox(height: 10),
                ElevatedButton(
                  onPressed: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(builder: (context) => ProjekatList()),
                    );
                  },
                  style: ElevatedButton.styleFrom(
                    primary: Colors.transparent,
                    onPrimary: Colors.white,
                    side: BorderSide(color: Colors.white, width: 2),
                  ),
                  child: Padding(
                    padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
                    child: Text('Projekti'),
                  ),
                ),
                SizedBox(height: 10),
                ElevatedButton(
                  onPressed: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(builder: (context) => KomisijaList()),
                    );
                  },
                  style: ElevatedButton.styleFrom(
                    primary: Colors.transparent,
                    onPrimary: Colors.white,
                    side: BorderSide(color: Colors.white, width: 2),
                  ),
                  child: Padding(
                    padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
                    child: Text('Komisija'),
                  ),
                ),
                SizedBox(height: 20),
                ListTile(
                  title: Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Icon(Icons.arrow_back),
                      SizedBox(width: 10),
                      Text(
                        'View all',
                        style: TextStyle(color: Colors.blue),
                      ),
                    ],
                  ),
                ),

              ],
            ),
          ),
        ],
      ),
      drawer: Drawer(
         key: _drawerKey,
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
            ListTile(
              title: Text('Timovi'),
              onTap: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => TimList()),
                );
              },
            ),
            ListTile(
              title: Text('Kriteriji'),
              onTap: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => KriterijiList()),
                );
              },
            ),
            ListTile(
              title: Text('Rezultati'),
              onTap: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => RezultatiList()),
                );
              },
            ),
            ListTile(
              title: Text('Odjavi se'),
              onTap: () {
                Navigator.of(context).pushReplacement(MaterialPageRoute(
                    builder: (context) => const LoginScreen()));
              },
            ),
          ],
        ),
      ),
    );
  }
}
