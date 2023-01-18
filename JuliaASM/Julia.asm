; Topic: Fractals Julii Method
; Desription: The program calculates a fractal using the Julia method 
; in a given range and for a given complex number C. The results are then displayed on the screen.
; 
; Author: Patryk Wik³acz
; Semester V 2022/2023
; 11.01.2023


.data
four dq 4.0
zero dq 0.0

.code

JuliiFunctionASM proc

; preparation of registers
xor rax, rax 
mov rsi, [rsp + 48]
mov rdi, [rsp + 40]
vmovupd ymm0, [rsi]
vmovupd ymm1, [rdx]
vbroadcastsd ymm2, xmm2
vbroadcastsd ymm3, xmm3
vmovupd ymm13, [four]
vbroadcastsd ymm13, xmm13
vxorpd ymm15, ymm15, ymm15
vxorpd ymm14, ymm14, ymm14

Julii_loop:
; Calculation of new values of zRe and zIm (zRe = zRe^2 - zIm^2, zIm = 2 * zRe * zIm)
vmovapd ymm4, ymm0 
vmovapd ymm5, ymm1
vmulpd ymm0, ymm0, ymm0
vmulpd ymm1, ymm1, ymm1
vsubpd ymm0, ymm0, ymm1
vmulpd ymm5, ymm5, ymm4
vaddpd ymm5, ymm5, ymm5
vmovapd ymm1, ymm5

; Adding cRe and cIm to zRe and zIm (zRe = zRe + cRe, zIm = zIm + cIm)
vaddpd ymm0, ymm0, ymm2
vaddpd ymm1, ymm1, ymm3
vmovapd ymm4, ymm0
vmovapd ymm5, ymm1

vmulpd ymm4, ymm4, ymm4   ; Calculation zRe^2
vmulpd ymm5, ymm5, ymm5   ; Calculation zIm^2
vaddpd ymm5, ymm5, ymm4   ; Calculation zRe^2 + zIm^2 (tmpRe = zRe^2 + zIm^2)

; Checking the stop condition
vcmpnlepd ymm5, ymm5, ymm13 
movd xmm8, rax
vbroadcastsd ymm8, xmm8
vpand ymm8, ymm8, ymm5
vpor ymm15, ymm15, ymm8
vpor ymm14, ymm14, ymm15
cmp rax,0
jz IfRaxZero

; Resetting the bits of the registers for which the result was found
CheckRegister:
vcmpeqpd ymm5, ymm5, zero
vpand ymm0, ymm0, ymm5
vpand ymm1, ymm1, ymm5
vpand ymm2, ymm2, ymm5
vpand ymm3, ymm3, ymm5
vpand ymm4, ymm4, ymm5
vpand ymm5, ymm5, ymm5

; Checking if a result is found for all 4 pixels
vextractf128 xmm12, ymm14, 0
comisd xmm12, zero
jz CounterInc
vpermq ymm12, ymm12, 39h
comisd xmm12, zero
jz CounterInc
vextractf128 xmm12, ymm14, 1
comisd xmm12, zero
jz CounterInc
vpermq ymm12, ymm12, 39h
comisd xmm12, zero
jne Julii_done
jmp CounterInc

; Increase the iteration counter and continue the loop
CounterInc:
inc rax ; Zwiêkszenie licznika iteracji o 1
cmp rax, rdi ; Porównanie licznika iteracji z maxIter
jb Julii_loop ; Jeœli licznik iteracji < maxIter, kontynuuj pêtlê
jmp Julii_done


; Returning the result
Julii_done:
movd xmm8, rax
vbroadcastsd ymm8, xmm8
vcmpeqpd ymm9, ymm14, zero
vpand ymm8, ymm8, ymm9
vpor ymm15, ymm15, ymm8
VPHADDD ymm0, ymm15, ymm15
vpermq ymm1, ymm0, 93h
vpermq ymm1, ymm0, 93h
movlhps xmm0, xmm1
movups [rcx], xmm0
ret 

; Checking the stop condition when the counter is 0
IfRaxZero:
mov rbx, rdi
inc rbx
movd xmm8, rbx
vbroadcastsd ymm8, xmm8
vpand ymm8, ymm8, ymm5
vpor ymm14, ymm14, ymm8
jmp CheckRegister

JuliiFunctionASM endp
end

