import 'package:json_annotation/json_annotation.dart';

part 'takmicenje.g.dart';

@JsonSerializable(explicitToJson: true)
class Takmicenje {
  int takmicenjeId;
  String naziv;
  String slogan;
  DateTime pocetak;
  DateTime kraj;
  int godina;
  int brojDana;
  String? slika;

  Takmicenje(this.takmicenjeId, this.naziv, this.slika, this.pocetak, this.kraj,
      this.godina, this.brojDana, this.slogan);

  factory Takmicenje.fromJson(Map<String, dynamic> json) =>
      _$TakmicenjeFromJson(json);
  Map<String, dynamic> toJson() => _$TakmicenjeToJson(this);
}
