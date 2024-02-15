import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:mobile_fitcc/Models/kategorija.dart';
import 'base_provider.dart';

class KategorijaProvider extends BaseProvider<Kategorija> {
  KategorijaProvider() : super("Kategorija");

  @override
  Kategorija fromJson(data) {
    return Kategorija.fromJson(data);
  }

}
