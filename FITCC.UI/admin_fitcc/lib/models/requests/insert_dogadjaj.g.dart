// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'insert_dogadjaj.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

DogadjajInsertRequest _$DogadjajInsertRequestFromJson(
        Map<String, dynamic> json) =>
    DogadjajInsertRequest(
      json['naziv'] as String,
      json['trajanje'] as int,
      DateTime.parse(json['pocetak'] as String),
      DateTime.parse(json['kraj'] as String),
      json['napomena'] as String?,
      json['agendaId'] as int,
      json['lokacija'] as String,
    );

Map<String, dynamic> _$DogadjajInsertRequestToJson(
        DogadjajInsertRequest instance) =>
    <String, dynamic>{
      'naziv': instance.naziv,
      'trajanje': instance.trajanje,
      'agendaId': instance.agendaId,
      'pocetak': instance.pocetak.toIso8601String(),
      'kraj': instance.kraj.toIso8601String(),
      'napomena': instance.napomena,
      'lokacija': instance.lokacija,
    };
