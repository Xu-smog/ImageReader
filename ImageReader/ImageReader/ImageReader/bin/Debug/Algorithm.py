import time
import packaging
import packaging.version
import packaging.specifiers
import packaging.requirements
import re
from pyhdf.HDF import *
from pyhdf.SD  import *
import matplotlib.pyplot as plt
import numpy as np
import math
from PIL import Image
import matplotlib
from osgeo import gdal
from osgeo import osr

Conf=open("Configure.txt","r")

def readhdf():
    filePath=Conf.readline()[:-1]
    savePath=Conf.readline()[:-1]
    nameList=filePath.split("\\")
    realName=nameList[-1].split(".")
    attrFile = open(savePath+"\\"+realName[0]+".txt", "w")
    hdfFile=SD(filePath,SDC.READ)
    attr =hdfFile.attributes(full=1)
    attrNames=attr.keys()
    for i in attrNames:
        value=attr[i]
        attrFile.write(value[0]+"\n")

    ds=hdfFile.datasets()
    for dsName in ds.keys():  
        dsObj=hdfFile.select(dsName)
        data=dsObj.get()
        cnt=0
        for depth in data:
            cnt=cnt+1
            prefix=re.sub(r"[^A-Za-z]","",dsName)
            plt.imsave(savePath+"\\"+prefix+"_band"+str(cnt)+".tif",depth,cmap="gray") 
    
def Jupipei():
    filePath=Conf.readline()[:-1]
    savePath=Conf.readline()[:-1]
    im=np.array(Image.open(filePath).convert('L'))

    rowNumber=im.shape[0]   
    colNumber=im.shape[1]
    midRow=int(colNumber/2)
    mu=im[:,midRow].mean()      
    sigma=im[:,midRow].std()       
    for i in range(0,colNumber):
        mui=im[:,i].mean()
        sigmai=im[:,i].std()
        if sigmai==0.0:
            sigmai=1.0
        a=sigma/sigmai
        b=mu-mui*a
        for j in range(0,rowNumber):
            im[j,i]=int(a*im[j,i]+b)

    plt.imsave(savePath,im,cmap="gray")


def Daoshu():
    savePath=Conf.readline()[:-1]
    imageNum=int(Conf.readline()[:-1])
    deriNum=int(Conf.readline()[:-1])
    
    image=[]
    deri=[]
    waveLength=[]

    for i in range(imageNum):
        filePath=Conf.readline()[:-1]
        image.append(np.array(Image.open(filePath).convert("L"))/255.0) 
        wl=float(Conf.readline()[:-1])
        waveLength.append(wl)
 
    if deriNum>=0:
        for i in range(imageNum):
            deri.append(np.zeros(image[0].shape))
        
        imax=-1.0

        for i in range(imageNum-1):
            deri[i]=(image[i+1]-image[i])/(waveLength[i+1]-waveLength[i])
            imax=max(imax,np.max(deri[i]))

        for i in range(imageNum-1):
            deri[i]=deri[i]/imax
            plt.imsave(savePath+"1\\"+str(time.time()).replace(".","")+".tif",deri[i],cmap="gray")
    
    if deriNum>=1:
        imax=-1.0

        for i in range(imageNum-2):
            deri[i]=(image[i+1]-image[i])/(waveLength[i+1]-waveLength[i])
            imax=max(imax,np.max(deri[i]))

        for i in range(imageNum-2):
            deri[i]=deri[i]/imax
            plt.imsave(savePath+"2\\"+str(time.time()).replace(".","")+".tif",deri[i],cmap="gray")

    if deriNum>=2:
        imax=-1.0

        for i in range(imageNum-3):
            deri[i]=(image[i+1]-image[i])/(waveLength[i+1]-waveLength[i])
            imax=max(imax,np.max(deri[i]))

        for i in range(imageNum-3):
            deri[i]=deri[i]/imax
            plt.imsave(savePath+"3\\"+str(time.time()).replace(".","")+".tif",deri[i],cmap="gray")        
    
def Correction():
    filePath=Conf.readline()[:-1]
    savePath=Conf.readline()[:-1]

    dataset = gdal.Open(filePath, gdal.GA_Update)

    n=int(Conf.readline()[:-1])

    gcps_list = []
    for i in range(n):
        x=float(Conf.readline()[:-1])
        y=float(Conf.readline()[:-1])
        p=int(Conf.readline()[:-1])
        l=int(Conf.readline()[:-1])
        gcps_list.append(gdal.GCP(x, y,  0, p, l))

    geogCS=Conf.readline()[:-1]
    sr = osr.SpatialReference()
    if geogCS=="EPSG":
        n=int(Conf.readline()[:-1])
        sr.SetWellKnownGeogCS(geogCS,n)
    else:
        sr.SetWellKnownGeogCS(geogCS)

    dataset.SetGCPs(gcps_list,sr.ExportToWkt())

    method=Conf.readline()[:-1]
    if method=="polynomialOrder":
        n=int(Conf.readline()[:-1])

    if method=="tps":
        gdal.Warp(savePath,dataset,tps=True)
    elif method=="polynomialOrder":
        gdal.Warp(savePath,dataset,polynomialOrder=n)
    elif method=="resampleAlg":
        gdal.Warp(savePath,dataset,resampleAlg=gdal.GRIORA_NearestNeighbour)
    else:
        gdal.Warp(savePath,dataset)

def makeRGB():
    redPath=Conf.readline()[:-1]
    greenPath=Conf.readline()[:-1]
    bluePath=Conf.readline()[:-1]
    savePath=Conf.readline()[:-1]

    red=np.array(Image.open(redPath).convert('L')).astype("int")
    green=np.array(Image.open(greenPath).convert('L')).astype("int")
    blue=np.array(Image.open(bluePath).convert('L')).astype("int")

    mr=np.max(red)
    mg=np.max(green)
    mb=np.max(blue)

    x=red.shape[0]
    y=red.shape[1]
    z=3

    fred=np.zeros((x,y)).astype("float")
    fgreen=np.zeros((x,y)).astype("float")
    fblue=np.zeros((x,y)).astype("float")

    for i in range(x):
        for j in range(y):
            fred[i,j]=red[i,j]/mr

    for i in range(x):
        for j in range(y):
            fgreen[i,j]=green[i,j]/mg

    for i in range(x):
        for j in range(y):
            fblue[i,j]=blue[i,j]/mb

    rgb=np.zeros((x,y,z)).astype("float")
    rgb[:,:,0]=fred
    rgb[:,:,1]=fgreen
    rgb[:,:,2]=fblue
            
    plt.imsave(savePath,rgb)

def Atm6S():
    xa=float(Conf.readline()[:-1])
    xb=float(Conf.readline()[:-1])
    xc=float(Conf.readline()[:-1])

    filePath=Conf.readline()[:-1]    
    savePath=Conf.readline()[:-1]
    mr=np.array(Image.open(filePath).convert('L'))
    y=xa*mr-xb
    acr=y/(1.0+xc*y)
    ma=np.max(acr)
    for i in range(acr.shape[0]):
        for j in range(acr.shape[1]):
            acr[i,j]=acr[i,j]/ma
    plt.imsave(savePath,acr,cmap="gray")
        
def Anyuan():
    filePath=Conf.readline()[:-1] 
    savePath=Conf.readline()[:-1] 
    grayImg = np.array(Image.open(filePath).convert('L'))

    rowNumber = grayImg.shape[0]
    colNumber = grayImg.shape[1]
    resImg=np.zeros(grayImg.shape)

    for i in range(rowNumber):
        for j in range(colNumber):
            data2=grayImg[i][j]

            u=128
            d=128
            l=128
            r=128

            if i>10:
                u=grayImg[i-10][j]

            if i<rowNumber-11:
                d=grayImg[i+10][j]

            if i>5:
                l=grayImg[i-5][j]
            if i<rowNumber-6:
                r=grayImg[i+5][j]

            temp2=(int(u)+int(d)+int(l)+int(r))/4


            if data2 < 30:
                data2 = temp2        

            resImg[i][j] = data2

    plt.imsave(savePath,resImg,cmap="gray")

def AtomCor():
    pass
    
n=Conf.readline()[:-1]
if n=="0":
    readhdf()
elif n=="1":
    AtomCor()
elif n=="2":
    Jupipei()
elif n=="3":
    Daoshu()
elif n=="4":
    Correction()
elif n=="5":
    makeRGB()
elif n=="6":
    Atm6S()
elif n=='7':
    Anyuan()