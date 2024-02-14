import 'package:json_annotation/json_annotation.dart';
import 'package:mobile_fitcc/Models/agenda.dart';

part 'dogadjaj.g.dart';

@JsonSerializable(explicitToJson: true)
class Dogadjaj {
  int dogadjajId;
  String naziv;
  int trajanje;
  int agendaId;
  DateTime pocetak;
  DateTime kraj;
  String napomena;
  String lokacija;
  Agenda agenda;

  Dogadjaj(
     this.dogadjajId,
      this.naziv,
      this.trajanje,
      this.pocetak,
      this.kraj,
      this.napomena,
      this.agenda,
      this.agendaId,
      this.lokacija);

  factory Dogadjaj.fromJson(Map<String, dynamic> json) =>
      _$DogadjajFromJson(json);
  Map<String, dynamic> toJson() => _$DogadjajToJson(this);
}
