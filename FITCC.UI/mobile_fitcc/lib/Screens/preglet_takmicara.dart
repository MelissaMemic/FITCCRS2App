import 'package:flutter/material.dart';
import 'package:mobile_fitcc/Models/user.dart';
import 'package:mobile_fitcc/Providers/user_provider.dart';
import 'package:mobile_fitcc/Screens/takmicar_detalji.dart';

class PregledTakmicaraScreen extends StatefulWidget {
  @override
  _PregledTakmicaraScreenState createState() => _PregledTakmicaraScreenState();
}

class _PregledTakmicaraScreenState extends State<PregledTakmicaraScreen> {
  List<User> korisnici = [];

  @override
  void initState() {
    super.initState();
    _fetchUserData();
  }

  Future<void> _fetchUserData() async {
    try {
      List<User> fetchedTakmicari =
          await UserProvider().getAllByRole("Takmicar");
      setState(() {
        korisnici = fetchedTakmicari;
      });
    } catch (e) {
      print('Error fetching Takmicari: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: ListView.builder(
        itemCount: korisnici.length,
        itemBuilder: (context, index) {
          final user = korisnici[index];
          return ListTile(
            title: Text('${user.firstName} ${user.lastName}'),
            subtitle: Text(user.webSite ?? 'N/A'),
            trailing: IconButton(
              icon: Icon(Icons.arrow_forward),
              onPressed: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(
                    builder: (context) => TakmicarDetaljiScreen(takmicar: user),
                  ),
                );
              },
            ),
          );
        },
      ),
    );
  }
}
