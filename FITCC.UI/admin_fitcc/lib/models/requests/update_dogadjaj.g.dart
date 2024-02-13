// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'update_dogadjaj.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

DogadjajUpdateRequest _$DogadjajUpdateRequestFromJson(
        Map<String, dynamic> json) =>
    DogadjajUpdateRequest(
      json['naziv'] as String,
      json['trajanje'] as int,
      DateTime.parse(json['pocetak'] as String),
      DateTime.parse(json['kraj'] as String),
      json['napomena'] as String?,
      json['agendaId'] as int,
      json['lokacija'] as String,
    );

Map<String, dynamic> _$DogadjajUpdateRequestToJson(
        DogadjajUpdateRequest instance) =>
    <String, dynamic>{
      'naziv': instance.naziv,
      'trajanje': instance.trajanje,
      'agendaId': instance.agendaId,
      'pocetak': instance.pocetak.toIso8601String(),
      'kraj': instance.kraj.toIso8601String(),
      'napomena': instance.napomena,
      'lokacija': instance.lokacija,
    };
