# -*- coding: utf-8 -*- 
import packaging
import packaging.version
import packaging.specifiers
import packaging.requirements
import re
import numpy as np
from pyhdf.HDF import *
from pyhdf.SD  import *
import matplotlib.pyplot as plt

def readhdf(fileName,savePath):

    nameList=fileName.split("\\")
    realName=nameList[-1].split(".")
    attrFile = open(savePath[:-1]+"\\"+realName[0]+".txt", "w")
    hdfFile=SD(fileName[:-1],SDC.READ)
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
            plt.imsave(savePath[:-1]+"\\"+prefix+"_band"+str(cnt)+".tif",depth) 

HDF=open("HDF.txt","r")
filePath=HDF.readline()
savePath=HDF.readline()
readhdf(filePath,savePath)   