// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'kriterij.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Kriterij _$KriterijFromJson(Map<String, dynamic> json) => Kriterij(
      json['kriterijId'] as int,
      json['naziv'] as String,
      json['vrijednost'] as String,
      json['kategorijaId'] as int,
    );

Map<String, dynamic> _$KriterijToJson(Kriterij instance) => <String, dynamic>{
      'kriterijId': instance.kriterijId,
      'naziv': instance.naziv,
      'vrijednost': instance.vrijednost,
      'kategorijaId': instance.kategorijaId,
    };
