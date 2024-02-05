
import 'package:admin_fitcc/models/takmicenje.dart';
import 'package:json_annotation/json_annotation.dart';

part 'kategorija.g.dart';

@JsonSerializable(explicitToJson: true)
class Kategorija {
 int kategorijaId;
   String naziv;
   String opis;
   Takmicenje takmicenje;
  Kategorija(  this.kategorijaId, this.naziv,this.opis, this.takmicenje);

  factory Kategorija.fromJson(Map<String, dynamic> json) => _$KategorijaFromJson(json);
  Map<String, dynamic> toJson() => _$KategorijaToJson(this);
}
