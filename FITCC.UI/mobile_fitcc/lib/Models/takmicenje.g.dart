// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'takmicenje.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Takmicenje _$TakmicenjeFromJson(Map<String, dynamic> json) => Takmicenje(
      json['takmicenjeId'] as int,
      json['naziv'] as String,
      json['slika'] as String?,
      DateTime.parse(json['pocetak'] as String),
      DateTime.parse(json['kraj'] as String),
      json['godina'] as int,
      json['brojDana'] as int,
      json['slogan'] as String,
    );

Map<String, dynamic> _$TakmicenjeToJson(Takmicenje instance) =>
    <String, dynamic>{
      'takmicenjeId': instance.takmicenjeId,
      'naziv': instance.naziv,
      'slogan': instance.slogan,
      'pocetak': instance.pocetak.toIso8601String(),
      'kraj': instance.kraj.toIso8601String(),
      'godina': instance.godina,
      'brojDana': instance.brojDana,
      'slika': instance.slika,
    };
