sudo hdparm -I /dev/sda | awk ' /Model Number/ {print}
							    /Serial Number/ {print}
								/Firmware Revision/ {print}
								/^\tUsed/ {print} 
								/^\tSupported/ {print}
								/DMA/ {print}
								/PIO/ {print}'
df -h --total | awk '/Файл.система/{printf "\t%s %s %s %s\n",$1,$2,$3,$4}
					/total/ {printf "\t%s %11s %6s %12s\n",$1,$2,$3,$4}'

