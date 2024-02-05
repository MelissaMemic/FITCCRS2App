
import 'package:admin_fitcc/models/kategorija.dart';
import 'package:admin_fitcc/models/tim.dart';
import 'package:json_annotation/json_annotation.dart';

part 'projekat.g.dart';

@JsonSerializable(explicitToJson: true)
class Projekat {
    int projekatId;
    String naziv;
    String opis;
    int kategorijaId;
    int timId;
    Kategorija kategorija; 
    Tim tim; 

  Projekat(
     this.projekatId,
     this.naziv,
     this.opis,
     this.kategorijaId,
     this.timId,
     this.kategorija,
     this.tim,  );

  factory Projekat.fromJson(Map<String, dynamic> json) => _$ProjekatFromJson(json);
  Map<String, dynamic> toJson() => _$ProjekatToJson(this);
}

