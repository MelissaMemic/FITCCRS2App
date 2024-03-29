import 'dart:convert';
import 'package:admin_fitcc/models/kriterij.dart';
import 'base_provider.dart';

class KriterijProvider extends BaseProvider<Kriterij> {
  KriterijProvider() : super("Kriteriji");

  @override
  Kriterij fromJson(data) {
    return Kriterij.fromJson(data);
  }

  Future<List<Kriterij>> fetchKriterijiList() async {
    var url = Uri.parse("https://localhost:7038/api/Kriterij/getLast");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<Kriterij>().toList();
    } else {
      throw Exception("Dogodila se greska");
    }
  }
}