import 'dart:convert';
import 'package:admin_fitcc/models/dogadjajagenda.dart';
import 'base_provider.dart';

class DogadjajPerAgendaProvider extends BaseProvider<DogadjajiPerAgenda> {
  DogadjajPerAgendaProvider() : super("api/Dogadjaj");

  @override
  DogadjajiPerAgenda fromJson(data) {
    return DogadjajiPerAgenda.fromJson(data);
  }

  Future<List<DogadjajiPerAgenda>> getAllDogadjaji() async {
    var url = Uri.parse("http://localhost:7247/Agenda/getAllDogadjaji");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<DogadjajiPerAgenda>().toList();
    } else {
      throw Exception("Dogodila se greska");
    }
  }
}