import 'package:json_annotation/json_annotation.dart';

part 'kriterij.g.dart';

@JsonSerializable(explicitToJson: true)
class Kriterij {
  int kriterijId;
   String naziv;
   String vrijednost;
   Kriterij kategorija;
   int kategorijaId;

  Kriterij(
    this.kriterijId,
    this.naziv,
    this.vrijednost,
    this.kategorijaId,
    this.kategorija);

  factory Kriterij.fromJson(Map<String, dynamic> json) => _$KriterijFromJson(json);
  Map<String, dynamic> toJson() => _$KriterijToJson(this);
}
