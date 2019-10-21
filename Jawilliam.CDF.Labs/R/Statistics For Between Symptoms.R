library(readr)

#BetweenSymptomsStats <- read_delim("D:/ExperimentLogs/BetweenSymptomsStats_28Vs30 - copia.txt", ";", escape_double = FALSE, trim_ws = TRUE)

#projects <- unique(BetweenSymptomsStats$Project)
#projects <- data.frame(projects)
#names(projects)[1] <- colnames(BetweenSymptomsStats)[1]

#approaches <- data.frame(approach=factor(), a28_Bp=double(), m28_Bp=double(), 
#                                               a29_BW=double(), m29_BW=double(), 
#                                               a30_BpIt=double(), m30_BpIt=double(),
#                                               a31_BW=double(), m31_BW=double(),
#                                               a32_It=double(), m32_It=double(),
#                                               a33_BW=double(), m33_BW=double(),
#                                               a34_BpDe=double(), m34_BpDe=double(),
#                                               a35_BW=double(), m35_BW=double(),
#                                               a36_BpDeIt=double(), m36_BpDeIt=double(),
#                                               a37_BW=double(), m37_BW=double() )
View(approaches)

#stats <- data.frame(BetweenSymptomsStats2_copia$Project, BetweenSymptomsStats2_copia$PrincipalRevisionPair)
#stats30Vs31 <- BetweenSymptomsStats2_copia[(BetweenSymptomsStats2_copia$`#lr_matches_31` != BetweenSymptomsStats2_copia$`#rl_matches_31`) | 
#                                           (BetweenSymptomsStats2_copia$`#lr_actions_31` != BetweenSymptomsStats2_copia$`#rl_actions_31`) |
#                                           (BetweenSymptomsStats2_copia$`#lr_inserts_31` != BetweenSymptomsStats2_copia$`#rl_deletes_31`) |
#                                           (BetweenSymptomsStats2_copia$`#lr_deletes_31` != BetweenSymptomsStats2_copia$`#rl_inserts_31`) |
#                                           (BetweenSymptomsStats2_copia$`#lr_updates_31` != BetweenSymptomsStats2_copia$`#rl_updates_31`) |
#                                           (BetweenSymptomsStats2_copia$`#lr_moves_31` != BetweenSymptomsStats2_copia$`#rl_moves_31`),]

# BetweenSymptomsStats <- read_delim("D:/ExperimentLogs/BetweenSymptomsStats_28Vs30.txt", ";", escape_double = FALSE, trim_ws = TRUE)
# total <- nrow(BetweenSymptomsStats)
# stats <- data.frame(a28Vs30_LR_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[28] != 0),])/total*100, 2),
#                     a30Vs28_RL_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[29] != 0),])/total*100, 2),
#                     #a28Vs30_Equal_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] == 0),])/total*100, 2),
#                     a28Vs30_NotEqual_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] != 0),])/total*100, 2),
#                     a28Vs30_LBest_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] < BetweenSymptomsStats[22]),])/total*100, 2),
#                     a30Vs28_RBest_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] > BetweenSymptomsStats[22]),])/total*100, 2),
#                     #a28Vs30_Equal_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] == BetweenSymptomsStats[22]),])/total*100, 2))
#                     a28Vs30_NotEqual_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] != BetweenSymptomsStats[22]),])/total*100, 2))
# 
# stats[2,]$a28Vs30_LBest_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] < BetweenSymptomsStats[22]),])
# stats[2,]$a30Vs28_RBest_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] > BetweenSymptomsStats[22]),])
# #stats[2,]$a28Vs30_Equal_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] == BetweenSymptomsStats[22]),])
# stats[2,]$a28Vs30_NotEqual_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] != BetweenSymptomsStats[22]),])
# stats[2,]$a28Vs30_LR_E = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[28] != 0),])
# stats[2,]$a30Vs28_RL_E = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[29] != 0),])
# #stats[2,]$a28Vs30_Equal_E = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] == 0),])
# stats[2,]$a28Vs30_NotEqual_E =nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] != 0),])

# BetweenSymptomsStats <- read_delim("D:/ExperimentLogs/BetweenSymptomsStats_28Vs29.txt", ";", escape_double = FALSE, trim_ws = TRUE)
# total <- nrow(BetweenSymptomsStats)
# stats <- data.frame(a28Vs29_LR_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[28] != 0),])/total*100, 2), 
#                     a29Vs28_RL_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[29] != 0),])/total*100, 2),
#                     #a28Vs29_Equal_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] == 0),])/total*100, 2),
#                     a28Vs29_NotEqual_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] != 0),])/total*100, 2),
#                     a28Vs29_LBest_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] < BetweenSymptomsStats[22]),])/total*100, 2), 
#                     a29Vs28_RBest_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] > BetweenSymptomsStats[22]),])/total*100, 2), 
#                     #a28Vs29_Equal_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] == BetweenSymptomsStats[22]),])/total*100, 2)) 
#                     a28Vs29_NotEqual_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] != BetweenSymptomsStats[22]),])/total*100, 2))
# 
# stats[2,]$a28Vs29_LBest_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] < BetweenSymptomsStats[22]),]) 
# stats[2,]$a29Vs28_RBest_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] > BetweenSymptomsStats[22]),]) 
# #stats[2,]$a28Vs29_Equal_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] == BetweenSymptomsStats[22]),]) 
# stats[2,]$a28Vs29_NotEqual_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] != BetweenSymptomsStats[22]),])
# stats[2,]$a28Vs29_LR_E = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[28] != 0),])
# stats[2,]$a29Vs28_RL_E = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[29] != 0),])
# #stats[2,]$a28Vs29_Equal_E = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] == 0),])
# stats[2,]$a28Vs29_NotEqual_E =nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] != 0),])


# BetweenSymptomsStats <- read_delim("D:/ExperimentLogs/BetweenSymptomsStats_28Vs32.txt", ";", escape_double = FALSE, trim_ws = TRUE)
# total <- nrow(BetweenSymptomsStats)
# stats <- data.frame(a28Vs32_LR_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[28] != 0),])/total*100, 2),
#                     a32Vs28_RL_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[29] != 0),])/total*100, 2),
#                     #a28Vs32_Equal_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] == 0),])/total*100, 2),
#                     a28Vs32_NotEqual_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] != 0),])/total*100, 2),
#                     a28Vs32_LBest_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] < BetweenSymptomsStats[22]),])/total*100, 2),
#                     a32Vs28_RBest_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] > BetweenSymptomsStats[22]),])/total*100, 2),
#                     #a28Vs32_Equal_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] == BetweenSymptomsStats[22]),])/total*100, 2))
#                     a28Vs32_NotEqual_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] != BetweenSymptomsStats[22]),])/total*100, 2))
# 
# stats[2,]$a28Vs32_LBest_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] < BetweenSymptomsStats[22]),])
# stats[2,]$a32Vs28_RBest_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] > BetweenSymptomsStats[22]),])
# #stats[2,]$a28Vs29_Equal_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] == BetweenSymptomsStats[22]),])
# stats[2,]$a28Vs32_NotEqual_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] != BetweenSymptomsStats[22]),])
# stats[2,]$a28Vs32_LR_E = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[28] != 0),])
# stats[2,]$a32Vs28_RL_E = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[29] != 0),])
# #stats[2,]$a28Vs29_Equal_E = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] == 0),])
# stats[2,]$a28Vs32_NotEqual_E =nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] != 0),])

# BetweenSymptomsStats <- read_delim("D:/ExperimentLogs/BetweenSymptomsStats_30Vs31.txt", ";", escape_double = FALSE, trim_ws = TRUE)
# total <- nrow(BetweenSymptomsStats)
# stats <- data.frame(a30Vs31_LR_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[28] != 0),])/total*100, 2),
#                     a31Vs30_RL_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[29] != 0),])/total*100, 2),
#                     #a30Vs31_Equal_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] == 0),])/total*100, 2),
#                     a30Vs31_NotEqual_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] != 0),])/total*100, 2),
#                     a30Vs31_LBest_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] < BetweenSymptomsStats[22]),])/total*100, 2),
#                     a31Vs30_RBest_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] > BetweenSymptomsStats[22]),])/total*100, 2),
#                     #a30Vs31_Equal_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] == BetweenSymptomsStats[22]),])/total*100, 2))
#                     a30Vs31_NotEqual_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] != BetweenSymptomsStats[22]),])/total*100, 2))
# 
# stats[2,]$a30Vs31_LBest_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] < BetweenSymptomsStats[22]),])
# stats[2,]$a31Vs30_RBest_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] > BetweenSymptomsStats[22]),])
# #stats[2,]$a30Vs31_Equal_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] == BetweenSymptomsStats[22]),])
# stats[2,]$a30Vs31_NotEqual_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] != BetweenSymptomsStats[22]),])
# stats[2,]$a30Vs31_LR_E = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[28] != 0),])
# stats[2,]$a31Vs30_RL_E = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[29] != 0),])
# #stats[2,]$a30Vs31_Equal_E = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] == 0),])
# stats[2,]$a30Vs31_NotEqual_E =nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] != 0),])

# BetweenSymptomsStats <- read_delim("D:/ExperimentLogs/BetweenSymptomsStats_30Vs32.txt", ";", escape_double = FALSE, trim_ws = TRUE)
# total <- nrow(BetweenSymptomsStats)
# stats <- data.frame(a30Vs32_LR_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[28] != 0),])/total*100, 2),
#                     a32Vs30_RL_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[29] != 0),])/total*100, 2),
#                     a30Vs32_NotEqual_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] != 0),])/total*100, 2),
#                     a30Vs32_LBest_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] < BetweenSymptomsStats[22]),])/total*100, 2),
#                     a32Vs30_RBest_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] > BetweenSymptomsStats[22]),])/total*100, 2),
#                     a30Vs32_NotEqual_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] != BetweenSymptomsStats[22]),])/total*100, 2))
# 
# stats[2,]$a30Vs32_LBest_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] < BetweenSymptomsStats[22]),])
# stats[2,]$a32Vs30_RBest_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] > BetweenSymptomsStats[22]),])
# stats[2,]$a30Vs32_NotEqual_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] != BetweenSymptomsStats[22]),])
# stats[2,]$a30Vs32_LR_E = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[28] != 0),])
# stats[2,]$a32Vs30_RL_E = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[29] != 0),])
# stats[2,]$a30Vs32_NotEqual_E =nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] != 0),])

# 
# BetweenSymptomsStats <- read_delim("D:/ExperimentLogs/BetweenSymptomsStats_32Vs33.txt", ";", escape_double = FALSE, trim_ws = TRUE)
# total <- nrow(BetweenSymptomsStats)
# stats <- data.frame(a32Vs33_LR_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[28] != 0),])/total*100, 2),
#                     a33Vs32_RL_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[29] != 0),])/total*100, 2),
#                     a32Vs33_NotEqual_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] != 0),])/total*100, 2),
#                     a32Vs33_LBest_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] < BetweenSymptomsStats[22]),])/total*100, 2),
#                     a33Vs32_RBest_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] > BetweenSymptomsStats[22]),])/total*100, 2),
#                     a32Vs33_NotEqual_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] != BetweenSymptomsStats[22]),])/total*100, 2))
# 
# stats[2,]$a32Vs33_LBest_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] < BetweenSymptomsStats[22]),])
# stats[2,]$a33Vs32_RBest_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] > BetweenSymptomsStats[22]),])
# stats[2,]$a32Vs33_NotEqual_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] != BetweenSymptomsStats[22]),])
# stats[2,]$a32Vs33_LR_E = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[28] != 0),])
# stats[2,]$a33Vs32_RL_E = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[29] != 0),])
# stats[2,]$a32Vs33_NotEqual_E =nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] != 0),])

BetweenSymptomsStats <- read_delim("D:/ExperimentLogs/BetweenSymptomsStats_36Vs37.txt", ";", escape_double = FALSE, trim_ws = TRUE)
total <- nrow(BetweenSymptomsStats)
stats <- data.frame(a36Vs37_LR_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[28] != 0),])/total*100, 2),
                    a37Vs36_RL_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[29] != 0),])/total*100, 2),
                    a36Vs37_NotEqual_E=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] != 0),])/total*100, 2),
                    a36Vs37_LBest_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] < BetweenSymptomsStats[22]),])/total*100, 2),
                    a37Vs36_RBest_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] > BetweenSymptomsStats[22]),])/total*100, 2),
                    a36Vs37_NotEqual_D=round(nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] != BetweenSymptomsStats[22]),])/total*100, 2))

stats[2,]$a36Vs37_LBest_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] < BetweenSymptomsStats[22]),])
stats[2,]$a37Vs36_RBest_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] > BetweenSymptomsStats[22]),])
stats[2,]$a36Vs37_NotEqual_D = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] != BetweenSymptomsStats[22]),])
stats[2,]$a36Vs37_LR_E = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[28] != 0),])
stats[2,]$a37Vs36_RL_E = nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[29] != 0),])
stats[2,]$a36Vs37_NotEqual_E =nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] != 0),])

View(stats)

View(BetweenSymptomsStats[which(BetweenSymptomsStats[16] != BetweenSymptomsStats[22]),])
#for (i in 1:nrow(stats)) 
#{
#  stats[i,1]
#}
