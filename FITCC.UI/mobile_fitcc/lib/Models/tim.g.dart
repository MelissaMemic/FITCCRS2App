// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'tim.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Tim _$TimFromJson(Map<String, dynamic> json) => Tim(
      json['timId'] as int,
      json['naziv'] as String?,
      json['brojClanova'] as int?,
      json['takmicenjeId'] as int?,
      Takmicenje.fromJson(json['takmicenje'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$TimToJson(Tim instance) => <String, dynamic>{
      'timId': instance.timId,
      'naziv': instance.naziv,
      'brojClanova': instance.brojClanova,
      'takmicenjeId': instance.takmicenjeId,
      'takmicenje': instance.takmicenje.toJson(),
    };
