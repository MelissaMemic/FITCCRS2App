// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'projekat.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Projekat _$ProjekatFromJson(Map<String, dynamic> json) => Projekat(
      json['projekatId'] as int,
      json['naziv'] as String,
      json['opis'] as String,
      json['kategorijaId'] as int,
      json['timId'] as int,
    );

Map<String, dynamic> _$ProjekatToJson(Projekat instance) => <String, dynamic>{
      'projekatId': instance.projekatId,
      'naziv': instance.naziv,
      'opis': instance.opis,
      'kategorijaId': instance.kategorijaId,
      'timId': instance.timId,
    };
