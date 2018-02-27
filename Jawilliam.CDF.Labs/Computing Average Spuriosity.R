#library(readr)

#SpuriosityPerElementTypes <- read_delim("E:/Phd/Analysis/UniquePairs/SpuriosityPerElementTypes.csv", ";", escape_double = FALSE, trim_ws = TRUE)
#spuriosityAvg <- data.frame(row.names = 1:nrow(SpuriosityPerElementTypes))
#spuriosityAvg <- cbind(spuriosityAvg, SpuriosityPerElementTypes[c(1,2)])
#spuriosityAvg <- cbind(spuriosityAvg, SpuriosityPerElementTypes[seq(4, length(SpuriosityPerElementTypes), 2)])

#for(i in 1:nrow(SpuriosityPerElementTypes))
#{
#  for (j in 1:((length(SpuriosityPerElementTypes)-2)/2)) 
#  {
#    spuriosityAvg[i,j+2] <- ifelse(SpuriosityPerElementTypes[i, 2* j + 1] == 0, 0, SpuriosityPerElementTypes[i, 2* j + 2]/SpuriosityPerElementTypes[i, 2* j + 1])
#    #b <- colnames(SpuriosityPerElementTypes)[2* i + 2]
#    #print(a)
#  }
#  print(i)
#}

#projects <- unique(GtLv$Project)
#spuriosityMedian <- data.frame(row.names = 1:length(projects))
#spuriosityMedian <- cbind(spuriosityMedian, projects)
#spuriosityMedian <- cbind(spuriosityMedian, spuriosityAvg[seq(1:nrow(spuriosityMedian)),seq(3, length(spuriosityAvg), 1)])
#for (i in 1:length(projects)) 
  #{
  #projectValues <- spuriosityAvg[which(spuriosityAvg$Project == projects[i]),]
  ##spuriosityMedian[i,1] <- projects[i]
  #for (j in 1:(length(spuriosityMedian)-1))
    #{
    #projectValues2 <- projectValues[which(projectValues[j+2] > 0),j+2]
    #spuriosityMedian[i,j+1] <- -1
    #spuriosityMedian[i,j+1] <- ifelse(length(projectValues2) > 0, median(projectValues2), 0)
    #  }
#}


#for (j in 1:(length(spuriosityMedian)-1))
#{
  #elementType = colnames(spuriosityMedian)[j+1]
  #print(elementType)
  
  #for (i in 1:length(projects)) 
  #{
    #projectValues <- spuriosityAvg[which(spuriosityAvg$Project == projects[i]),]
    #projectValues2 <- projectValues[which(projectValues[j+2] > 0),j+2]
    #if((length(projectValues2) > 0))
    #{
      #p <- quantile(projectValues2, seq(0,1,0.01))
     # write.table(p, paste("E:/Phd/Analysis/UniquePairs/", projects[i], "PercentilesFor", elementType, ".csv", sep=""), sep=";", row.names=TRUE)
    #}
   # #projectValues <- spuriosityAvg[which(spuriosityAvg$Project == projects[i]),]
  #  #spuriosityMedian[i,1] <- projects[i]
    
    
 # }
#}

#tails <- data.frame(row.names=spuriosityMedian$projects)
#tails <- cbind(tails, spuriosityMedian[seq(1:nrow(spuriosityMedian)),seq(2, length(spuriosityMedian), 1)])
#for (j in 1:(length(spuriosityMedian)-1))
#{
  #elementType = colnames(spuriosityMedian)[j+1]
  #print(elementType)
  
  #for (i in 1:length(projects)) 
  #{
    #tails[i,j] <- 0
    #projectValues <- spuriosityAvg[which(spuriosityAvg$Project == projects[i]),]
    #projectValues2 <- projectValues[which(projectValues[j+2] > 0),j+2]
    #if((length(projectValues2) > 0))
    #{
      #p <- quantile(projectValues2, seq(0,1,0.01))
      #tails[i,j] <- p[91]
     # #write.table(p, paste("E:/Phd/Analysis/UniquePairs/", projects[i], "PercentilesFor", elementType, ".csv", sep=""), sep=";", row.names=TRUE)
    #}
   # #projectValues <- spuriosityAvg[which(spuriosityAvg$Project == projects[i]),]
  #  #spuriosityMedian[i,1] <- projects[i]
 # }
#}

medianTails <- data.frame(row.names = 1)
medianTails <- cbind(medianTails, tails[1,seq(1,length(tails),1)])
for(k in 1:length(tails))
{
  medianTails[1,k] <- median(tails[,k])
}
write.table(t(medianTails), paste("E:/Phd/Analysis/UniquePairs/MedianTailThs.csv", sep=""), sep=";", row.names=TRUE)
#medianTailTh <- cbind(medianTailTh, medianTails[1,])


