// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'kategorija.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Kategorija _$KategorijaFromJson(Map<String, dynamic> json) => Kategorija(
      json['kategorijaId'] as int,
      json['naziv'] as String,
      json['opis'] as String,
      Takmicenje.fromJson(json['takmicenje'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$KategorijaToJson(Kategorija instance) =>
    <String, dynamic>{
      'kategorijaId': instance.kategorijaId,
      'naziv': instance.naziv,
      'opis': instance.opis,
      'takmicenje': instance.takmicenje.toJson(),
    };
