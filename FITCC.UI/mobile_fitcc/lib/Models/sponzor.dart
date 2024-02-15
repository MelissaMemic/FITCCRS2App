import 'package:json_annotation/json_annotation.dart';
part 'sponzor.g.dart';

@JsonSerializable(explicitToJson: true)
class Sponzor {
  int sponzorId;
  String naziv;
  int? godina;
  int skategorijeId;
  int? kategorijaId;

  Sponzor(
      this.sponzorId, this.naziv, this.godina, this.skategorijeId, this.kategorijaId);

  factory Sponzor.fromJson(Map<String, dynamic> json) =>
      _$SponzorFromJson(json);
  Map<String, dynamic> toJson() => _$SponzorToJson(this);
}
