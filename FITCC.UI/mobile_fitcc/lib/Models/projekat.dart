
import 'package:json_annotation/json_annotation.dart';
import 'package:mobile_fitcc/Models/tim.dart';

part 'projekat.g.dart';

@JsonSerializable(explicitToJson: true)
class Projekat {
    int projekatId;
    String naziv;
    String opis;
    int kategorijaId;
    int timId;
    Tim tim;

  Projekat(
     this.projekatId,
     this.naziv,
     this.opis,
     this.kategorijaId,
     this.timId,
     this.tim
       );

  factory Projekat.fromJson(Map<String, dynamic> json) => _$ProjekatFromJson(json);
  Map<String, dynamic> toJson() => _$ProjekatToJson(this);
}

