import 'package:json_annotation/json_annotation.dart';

part 'upsert_dogadjaj.g.dart';

@JsonSerializable()
class UpsertDogadjaj {
  String naziv;
  int trajanje;
  DateTime pocetak;
  String napomena;
  int agendaId;
  String lokacija;

  UpsertDogadjaj(
      this.naziv,
      this.trajanje,
      this.pocetak,
      this.napomena,
      this.agendaId,
      this.lokacija,

  );

  factory UpsertDogadjaj.fromJson(Map<String, dynamic> json) =>
      _$UpsertDogadjajFromJson(json);

  Map<String, dynamic> toJson() => _$UpsertDogadjajToJson(this);
}
