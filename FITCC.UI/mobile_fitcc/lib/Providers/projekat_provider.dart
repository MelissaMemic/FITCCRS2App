import 'dart:convert';
import 'package:mobile_fitcc/Models/projekat.dart';
import 'base_provider.dart';

class ProjekatProvider extends BaseProvider<Projekat> {
  ProjekatProvider() : super("Projekat");

  @override
  Projekat fromJson(data) {
    return Projekat.fromJson(data);
  }

  Future<List<Projekat>> fetchProjekatiList() async {
    var url = Uri.parse("http://localhost:7247/api/Projekat");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<Projekat>().toList();
    } else {
      throw Exception("Dogodila se greska");
    }
  }
}