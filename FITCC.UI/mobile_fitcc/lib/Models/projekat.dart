
import 'package:json_annotation/json_annotation.dart';

part 'projekat.g.dart';

@JsonSerializable(explicitToJson: true)
class Projekat {
    int projekatId;
    String naziv;
    String opis;
    int kategorijaId;
    int timId;

  Projekat(
     this.projekatId,
     this.naziv,
     this.opis,
     this.kategorijaId,
     this.timId
       );

  factory Projekat.fromJson(Map<String, dynamic> json) => _$ProjekatFromJson(json);
  Map<String, dynamic> toJson() => _$ProjekatToJson(this);
}

