import 'package:json_annotation/json_annotation.dart';

part 'agenda.g.dart';

@JsonSerializable(explicitToJson: true)
class Agenda {
  int agendaId;
  int? dan;
  int? takmicenjeId;
  dynamic takmicenje; 

  Agenda(
     this.agendaId,
    this.dan,
   this.takmicenje, 
   this.takmicenjeId, 
  );

  factory Agenda.fromJson(Map<String, dynamic> json) => _$AgendaFromJson(json);
  Map<String, dynamic> toJson() => _$AgendaToJson(this);
}
