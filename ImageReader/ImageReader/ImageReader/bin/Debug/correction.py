from osgeo import gdal
from osgeo import osr

Cor=open("Correction.txt","r")
filePath=Cor.readline()[:-1]
savePath=Cor.readline()[:-1]

dataset = gdal.Open(filePath, gdal.GA_Update)

n=int(Cor.readline()[:-1])

gcps_list = []
for i in range(n):
	x=float(Cor.readline()[:-1])
	y=float(Cor.readline()[:-1])
	p=int(Cor.readline()[:-1])
	l=int(Cor.readline()[:-1])
	gcps_list.append(gdal.GCP(x, y,  0, p, l))

geogCS=Cor.readline()[:-1]
sr = osr.SpatialReference()
if geogCS=="EPSG":
	n=int(Cor.readline()[:-1])
	sr.SetWellKnownGeogCS(geogCS,n)
else:
	sr.SetWellKnownGeogCS(geogCS)

dataset.SetGCPs(gcps_list,sr.ExportToWkt())

method=Cor.readline()[:-1]
if method=="polynomialOrder":
	n=int(Cor.readline()[:-1])

if method=="tps":
	gdal.Warp(savePath,dataset,tps=True)
elif method=="polynomialOrder":
	gdal.Warp(savePath,dataset,polynomialOrder=n)
elif method=="resampleAlg":
	gdal.Warp(savePath,dataset,resampleAlg=gdal.GRIORA_NearestNeighbour)
else:
	gdal.Warp(savePath,dataset)
