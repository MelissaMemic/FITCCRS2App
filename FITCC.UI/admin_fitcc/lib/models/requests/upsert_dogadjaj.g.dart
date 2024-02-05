// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'upsert_dogadjaj.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

UpsertDogadjaj _$UpsertDogadjajFromJson(Map<String, dynamic> json) =>
    UpsertDogadjaj(
      json['naziv'] as String,
      json['trajanje'] as int,
      DateTime.parse(json['pocetak'] as String),
      json['napomena'] as String,
      json['agendaId'] as int,
      json['lokacija'] as String,
    );

Map<String, dynamic> _$UpsertDogadjajToJson(UpsertDogadjaj instance) =>
    <String, dynamic>{
      'naziv': instance.naziv,
      'trajanje': instance.trajanje,
      'pocetak': instance.pocetak.toIso8601String(),
      'napomena': instance.napomena,
      'agendaId': instance.agendaId,
      'lokacija': instance.lokacija,
    };
