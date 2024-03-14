// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'update_tim.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

TimUpdateRequest _$TimUpdateRequestFromJson(Map<String, dynamic> json) =>
    TimUpdateRequest(
      json['naziv'] as String?,
      json['brojClanova'] as int?,
      json['takmicenjeId'] as int?,
    );

Map<String, dynamic> _$TimUpdateRequestToJson(TimUpdateRequest instance) =>
    <String, dynamic>{
      'naziv': instance.naziv,
      'brojClanova': instance.brojClanova,
      'takmicenjeId': instance.takmicenjeId,
    };
