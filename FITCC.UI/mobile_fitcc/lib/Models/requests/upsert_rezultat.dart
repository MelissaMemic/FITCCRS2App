import 'package:json_annotation/json_annotation.dart';

part 'upsert_rezultat.g.dart';

@JsonSerializable(explicitToJson: true)
class RezultatUpsertRequest {
   int? bod;
   String? napomena;
   int? projekatId;
  RezultatUpsertRequest(
    this.bod,
    this.napomena,
    this.projekatId
    );

  factory RezultatUpsertRequest.fromJson(Map<String, dynamic> json) => _$RezultatUpsertRequestFromJson(json);
  Map<String, dynamic> toJson() => _$RezultatUpsertRequestToJson(this);
}
