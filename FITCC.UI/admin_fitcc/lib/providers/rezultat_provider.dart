import 'dart:convert';
import 'package:admin_fitcc/models/rezultat.dart';
import 'base_provider.dart';

class RezultatProvider extends BaseProvider<Rezultat> {
  RezultatProvider() : super("Rezultat");

  @override
  Rezultat fromJson(data) {
    return Rezultat.fromJson(data);
  }

  Future<List<Rezultat>> fetchRezultatiList() async {
    var url = Uri.parse("https://localhost:7038/api/Rezultat");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<Rezultat>().toList();
    } else {
      throw Exception("Dogodila se greska");
    }
  }

  Future<List<Rezultat>> getAllRezultati() async {
    var url = Uri.parse("https://localhost:7038/api/Rezultati/getAllRezultati");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<Rezultat>().toList();
    } else {
      throw Exception("Dogodila se greska");
    }
  }

}