// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'upsert_rezultat.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

RezultatUpsertRequest _$RezultatUpsertRequestFromJson(
        Map<String, dynamic> json) =>
    RezultatUpsertRequest(
      json['bod'] as int?,
      json['napomena'] as String?,
      json['projekatId'] as int?,
    );

Map<String, dynamic> _$RezultatUpsertRequestToJson(
        RezultatUpsertRequest instance) =>
    <String, dynamic>{
      'bod': instance.bod,
      'napomena': instance.napomena,
      'projekatId': instance.projekatId,
    };
