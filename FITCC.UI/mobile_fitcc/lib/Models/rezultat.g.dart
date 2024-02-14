// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'rezultat.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Rezultat _$RezultatFromJson(Map<String, dynamic> json) => Rezultat(
      json['rezultatId'] as int,
      json['bod'] as int,
      json['napomena'] as String,
      json['projekatId'] as int,
      Projekat.fromJson(json['projekat'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$RezultatToJson(Rezultat instance) => <String, dynamic>{
      'rezultatId': instance.rezultatId,
      'bod': instance.bod,
      'napomena': instance.napomena,
      'projekatId': instance.projekatId,
      'projekat': instance.projekat.toJson(),
    };
