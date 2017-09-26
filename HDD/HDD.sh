sudo hdparm -I /dev/sda | awk ' /Model Number/ {print}
							    /Serial Number/ {print}
								/Firmware Revision/ {print}
								/^\tUsed/ {print} 
								/^\tSupported/ {print}
								/DMA/ {print}
								/PIO/ {print}'
df -h | awk '{print "\t"$1"\t"$2"\t"$3"\t"$4}'
