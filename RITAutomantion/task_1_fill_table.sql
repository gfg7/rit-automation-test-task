declare @i int =0;
declare @maxLat int =90;
declare @maxLong int =180;
declare @partLat int;
declare @partLong int;

while @i<100
begin 
set @partLat = case when rand()>0.5 then 1 else -1 end;
set @partLong = case when rand()>0.5 then 1 else -1 end;
INSERT INTO GeoPointMarkers (Longitude, Latitude) 
VALUES (round((@maxLong - 1)*rand() * @partLong,5), round((@maxLat -1)*rand()*@partLat,5));
set @i = @i+1;
end;