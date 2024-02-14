import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:mobile_fitcc/Screens/Auth/login.dart';
import 'package:mobile_fitcc/Screens/home_page.dart';
import 'package:mobile_fitcc/Screens/pregled_agenda.dart';
import 'package:mobile_fitcc/Screens/pregled_projekata.dart';
import 'package:mobile_fitcc/Screens/preglet_takmicara.dart';
import 'package:mobile_fitcc/Screens/welcome_screen.dart';

void main() {
  WidgetsFlutterBinding.ensureInitialized();
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  MyApp({Key? key}) : super(key: key);

  @override
  var routes = {
    "/welcome": (context) => WelcomeScreen(),
    "/login": (context) => LoginScreen(),
     "/pregledTakmicara": (context) => PregledTakmicaraScreen(),
     "/pregledProjekataZiri": (context) => PregledProjekataScreen(),
    "/agendaZiriPregled": (context) => PregledAgendaScreen(),
    "/homePage": (context) => HomePage(),
  };

  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Welcome to FITCC app',
      home: const LoginScreen(),
      routes: routes,
    );
  }
}
