import 'package:flutter/material.dart';
import 'package:mobile_fitcc/Models/auth_user.dart';
import 'package:mobile_fitcc/Providers/login_provider.dart';
import 'package:mobile_fitcc/Providers/user_provider.dart';
import 'package:mobile_fitcc/Screens/Auth/login.dart';
import 'package:mobile_fitcc/Screens/pregled_agenda.dart';
import 'package:mobile_fitcc/Screens/preglet_takmicara.dart';
import 'package:mobile_fitcc/Screens/agenda_screen.dart';
import 'package:mobile_fitcc/Screens/pocetna_takmicar_screen.dart';
import 'package:mobile_fitcc/Screens/pregled_projekata.dart';
import 'package:mobile_fitcc/my_drawer_header.dart';

class HomePage extends StatefulWidget {
  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  bool isTakmicar = false;
  bool isZiri = false;
  bool isAdmin = false;
  var currentPage = DrawerSections.pocetnaTakmicar;

  @override
  void initState() {
    _fetchDataIsTakmicar();
    _fetchDataIsKomisija();
    _fetchDataIsAdmin();
  }

  Future<void> _fetchDataIsTakmicar() async {
    bool something = false;
    if (AuthUser.roles.contains("Takmicar")) {
      something = true;
    }
    setState(() {
      isTakmicar = something;
    });
  }

  Future<void> _fetchDataIsAdmin() async {
    bool something = false;
    if (AuthUser.roles.contains("Admin")) {
      something = true;
    }
    setState(() {
      isAdmin = something;
    });
  }

  Future<void> _fetchDataIsKomisija() async {
    bool something = false;
    if (AuthUser.roles.contains("Ziri")) {
      something = true;
    }
    setState(() {
      isZiri = something;
    });
  }

  @override
  Widget build(BuildContext context) {
    var containter;
    if (currentPage == DrawerSections.pocetnaTakmicar) {
      containter = PocetnaTakmicarScreen();
    } else if (currentPage == DrawerSections.agenda) {
      containter = AgendaScreen();
    } else if (currentPage == DrawerSections.pregledProjekataZiri) {
      containter = PregledProjekataScreen();
    } else if (currentPage == DrawerSections.pregledTakmicara) {
      containter = PregledTakmicaraScreen();
    } else if (currentPage == DrawerSections.pregledAgende) {
      containter = PregledAgendaScreen();
    }

    return Scaffold(
      appBar: AppBar(
        title: Text(
          "FITCC",
          style: TextStyle(fontSize: 20),
        ),
        backgroundColor: Colors.black,
      ),
      body: containter,
      drawer: Drawer(
        child: SingleChildScrollView(
            child: Container(
          child: Column(
            children: [
              MyDrawerHeader(),
              MyDrawerList(),
            ],
          ),
        )),
      ),
    );
  }

  Widget MyDrawerList() {
    return Container(
      padding: EdgeInsets.only(top: 15),
      child: Column(children: [
        menuItem(1, "Pocetna",
            currentPage == DrawerSections.pocetnaTakmicar ? true : false),
        if (AuthUser.roles.contains("Takmicar"))
          menuItem(2, "Tim",
              currentPage == DrawerSections.takmicenjePrijava ? true : false),
        if (AuthUser.roles.contains("Takmicar"))
          menuItem(3, "Projekat",
              currentPage == DrawerSections.projekatPrjava ? true : false),
        if (AuthUser.roles.contains("Admin"))
          menuItem(
            4, "Agenda", currentPage == DrawerSections.agenda ? true : false),
        if (AuthUser.roles.contains("Sponzor"))
          menuItem(11, "Pregled Takmicara",
            currentPage == DrawerSections.pregledTakmicara ? true : false),
        menuItem(6, "Moj profil",
            currentPage == DrawerSections.profil ? true : false),
        if (AuthUser.roles.contains("Ziri"))
          menuItem(
              10,
              "Pregled projekata",
              currentPage == DrawerSections.pregledProjekataZiri
                  ? true
                  : false),
        menuItem(12, "Pregled agende",
              currentPage == DrawerSections.pregledAgende ? true : false),
        if (AuthUser.roles.contains("Takmicar"))
          menuItem(
              7, "Moj CV", currentPage == DrawerSections.cv ? true : false),
        if (AuthUser.roles.contains("Takmicar"))
          menuItem(9, "Pregled prijava",
              currentPage == DrawerSections.pregledtimptojekat ? true : false),
        Container(
          child: TextButton(
              onPressed: () {
                Navigator.of(context).pushReplacement(MaterialPageRoute(
                    builder: (context) => const LoginScreen()));
              },
              child: Text("Logout")),
        )
      ]),
    );
  }

  Widget menuItem(int id, String title, bool selected) {
    return Material(
      color: selected ? Color.fromARGB(255, 219, 243, 255) : Colors.transparent,
      child: InkWell(
        onTap: () {
          Navigator.pop(context);
          setState(() {
            if (id == 1) {
              currentPage = DrawerSections.pocetnaTakmicar;
            } else if (id == 2) {
              currentPage = DrawerSections.takmicenjePrijava;
            } else if (id == 3) {
              currentPage = DrawerSections.projekatPrjava;
            } else if (id == 4) {
              currentPage = DrawerSections.agenda;
            } else if (id == 5) {
              currentPage = DrawerSections.login;
            } else if (id == 6) {
              currentPage = DrawerSections.profil;
            } else if (id == 7) {
              currentPage = DrawerSections.cv;
            } else if (id == 8) {
              currentPage = DrawerSections.rezultat;
            } else if (id == 9) {
              currentPage = DrawerSections.pregledtimptojekat;
            } else if (id == 10) {
              currentPage = DrawerSections.pregledProjekataZiri;
            } else if (id == 11) {
              currentPage = DrawerSections.pregledTakmicara;
            } else if (id == 12) {
              currentPage = DrawerSections.pregledAgende;
            }
          });
        },
        child: Padding(
          padding: EdgeInsets.all(15.0),
          child: Row(
            children: [
              Expanded(
                  flex: 1,
                  child: Text(
                    title,
                    style: TextStyle(color: Colors.black, fontSize: 14.0),
                  ))
            ],
          ),
        ),
      ),
    );
  }
}

enum DrawerSections {
  pocetnaTakmicar,
  projekatPrjava,
  cv,
  profil,
  agenda,
  pregledTakmicara,
  takmicenjePrijava,
  login,
  rezultat,
  pregledtimptojekat,
  pregledProjekataZiri,
  pregledAgende
}
