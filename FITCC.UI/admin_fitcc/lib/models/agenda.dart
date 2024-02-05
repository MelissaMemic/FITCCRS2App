import 'package:admin_fitcc/models/takmicenje.dart';
import 'package:json_annotation/json_annotation.dart';

part 'agenda.g.dart';

@JsonSerializable(explicitToJson: true)
class Agenda {
  int agendaId;
  int? dan;
  Takmicenje? takmicenje; 

  Agenda(
     this.agendaId,
    this.dan,
   this.takmicenje, 
  );

  factory Agenda.fromJson(Map<String, dynamic> json) => _$AgendaFromJson(json);
  Map<String, dynamic> toJson() => _$AgendaToJson(this);
}
