// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'insert_tim.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

TimInsertRequest _$TimInsertRequestFromJson(Map<String, dynamic> json) =>
    TimInsertRequest(
      json['takmicenjeId'] as int?,
      json['naziv'] as String?,
      json['brojClanova'] as int?,
    );

Map<String, dynamic> _$TimInsertRequestToJson(TimInsertRequest instance) =>
    <String, dynamic>{
      'naziv': instance.naziv,
      'brojClanova': instance.brojClanova,
      'takmicenjeId': instance.takmicenjeId,
    };
