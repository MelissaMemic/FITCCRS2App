
import 'dart:convert';
import 'package:admin_fitcc/models/takmicenje.dart';
import 'base_provider.dart';

class TakmicenjeProvider extends BaseProvider<Takmicenje> {
  TakmicenjeProvider() : super("Takmicenje");

  @override
  Takmicenje fromJson(data) {
    return Takmicenje.fromJson(data);
  }

  Future<int> getLastTakmicenje() async {
    var url = Uri.parse("http://localhost:7247/Takmicenje/getLastTakmicenje");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      return int.parse(response.body);
    } else {
      throw Exception("Dogodila se greska");
    }
  }
  
}