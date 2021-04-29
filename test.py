from pynput.keyboard import Key, Controller, Listener

with open("data.txt", "r") as data_file:
    data = data_file.readlines()



keyboard = Controller()

def input_data(key):
    if key == Key.f12:
        for d in data:
            keyboard.type(f"{d}")

with Listener(on_release=input_data, ) as listener:
    listener.join()