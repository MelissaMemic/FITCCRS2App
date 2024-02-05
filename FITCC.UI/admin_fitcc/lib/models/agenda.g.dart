// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'agenda.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Agenda _$AgendaFromJson(Map<String, dynamic> json) => Agenda(
      json['agendaId'] as int,
      json['dan'] as int?,
      json['takmicenje'] == null
          ? null
          : Takmicenje.fromJson(json['takmicenje'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$AgendaToJson(Agenda instance) => <String, dynamic>{
      'agendaId': instance.agendaId,
      'dan': instance.dan,
      'takmicenje': instance.takmicenje?.toJson(),
    };
