import 'dart:convert';
import 'package:mobile_fitcc/Models/dogadjaj.dart';
import 'base_provider.dart';

class DogadjajProvider extends BaseProvider<Dogadjaj> {
  DogadjajProvider() : super("Dogadjaj");
  @override
  Dogadjaj fromJson(data) {
    return Dogadjaj.fromJson(data);
  }


  Future<List> getDogadjeTakmicenja() async {
    var url = Uri.parse("http://localhost:7247/api/Dogadjaj/getLast");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data;
    } else {
      throw Exception("Dogodila se greska");
    }
  }
}
