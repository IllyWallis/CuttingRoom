import cv2
from cvzone.HandTrackingModule import HandDetector
import socket

#parameters
width, height = 1280, 720

# initialise opencv webcam
cap = cv2.VideoCapture(1)
cap.set(3,width)
cap.set(4,height)

# Hand detection using cvzone
detector = HandDetector(maxHands=4, detectionCon=0.8)

#Communication with unity using socket
sock = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
serverAddressPort = ("127.0.0.1", 5052)

while True:
    # webcam framing
    success, img = cap.read()

    #Hands detection
    hands, img = detector.findHands(img)


    data = []


    # Send to Unity - (x, y, z) * 21
    if hands:
        # first hand detected
        hand = hands[0]
        # landmark list
        lmList = hand['lmList']
        # print(lmList)

        for lm in lmList:
            data.extend([lm[0], height - lm[1], lm[2]])
        print(data)
        sock.sendto(str.encode(str(data)), serverAddressPort)


    cv2.imshow("Image", img)
    cv2.waitKey(1)