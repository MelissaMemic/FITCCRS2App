// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'dogadjaj.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Dogadjaj _$DogadjajFromJson(Map<String, dynamic> json) => Dogadjaj(
      json['dogadjajId'] as int,
      json['naziv'] as String,
      json['trajanje'] as int,
      DateTime.parse(json['pocetak'] as String),
      DateTime.parse(json['kraj'] as String),
      json['napomena'] as String,
      Agenda.fromJson(json['agenda'] as Map<String, dynamic>),
      json['agendaId'] as int,
      json['lokacija'] as String,
    );

Map<String, dynamic> _$DogadjajToJson(Dogadjaj instance) => <String, dynamic>{
      'dogadjajId': instance.dogadjajId,
      'naziv': instance.naziv,
      'trajanje': instance.trajanje,
      'agendaId': instance.agendaId,
      'pocetak': instance.pocetak.toIso8601String(),
      'kraj': instance.kraj.toIso8601String(),
      'napomena': instance.napomena,
      'lokacija': instance.lokacija,
      'agenda': instance.agenda.toJson(),
    };
